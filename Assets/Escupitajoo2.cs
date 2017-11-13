using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escupitajoo2 : MonoBehaviour {

    private Transform playerTrans;

    Rigidbody2D escupitajoRB;

    public float escupitajoSpeed;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        escupitajoRB = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        if(playerTrans.localPosition.x < transform.localPosition.x){

            escupitajoRB.velocity = new Vector2(-escupitajoSpeed, escupitajoRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {

            escupitajoRB.velocity = new Vector2(escupitajoSpeed, escupitajoRB.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);



        }

        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("EnemyKnockBack", transform.position.x);
            anim.SetBool("Choque", true);
            Destroy(this.gameObject, 0.4f);

        }

        if (other.tag == "Ground")
        {
            anim.SetBool("Choque", true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(this.gameObject, 0.4f);

        }
    }
}
