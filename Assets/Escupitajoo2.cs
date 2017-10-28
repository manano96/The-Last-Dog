using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escupitajoo2 : MonoBehaviour {

    private GameObject barravida;
    private Animator anim;
    private Rigidbody2D rgb2;
    private GameObject Player;
    private GameObject Enemy4;


    public float Destroygota;

    // Use this for initialization
    void Start()
    {
        barravida = GameObject.Find("barravida");
        rgb2 = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemy4 = GameObject.FindGameObjectWithTag("Enemy4");

        anim = this.gameObject.GetComponent<Animator>();

        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

        float xenemy = Enemy4.transform.position.x;
        float xplayer = Player.transform.position.x;


        if (xenemy >= xplayer)
        {
            rgb2.AddForce(Vector2.left * 6f * 6f);
            
        }

        if (xenemy <= xplayer)
        {
            rgb2.AddForce(Vector2.right * 6f * 6f);
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("EnemyKnockBack", transform.position.x);
            anim.SetBool("Choque", true);
            Destroy(this.gameObject, Destroygota);

        }

        if (other.tag == "Ground")
        {
            anim.SetBool("Choque", true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(this.gameObject, Destroygota);

        }
    }
}
