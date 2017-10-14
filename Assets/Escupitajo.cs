using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escupitajo : MonoBehaviour {

    private GameObject barravida;
    private Animator anim;

    public float Destroygota;

    // Use this for initialization
    void Start()
    {
        barravida = GameObject.Find("barravida");

        anim = this.gameObject.GetComponent<Animator>();
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