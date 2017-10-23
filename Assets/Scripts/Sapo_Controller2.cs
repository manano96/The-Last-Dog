using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo_Controller2 : MonoBehaviour {

    private GameObject player;
    private GameObject tope;

    private float play;

    public bool caida;
    public bool onetime;


    private float Ataque1;
    private float Ataque2;


    public float speed = 1.0F;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tope = GameObject.FindGameObjectWithTag("Tope");

        play = player.transform.position.x;

        
    }


    void Update()
    {
        Ataque1 = Vector2.Distance(this.transform.position, player.transform.position);


        if (caida)
        {
            Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * speed, (transform.position.y - tope.transform.position.y) * speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        }

        if (onetime)
        {
            Invoke("Cad", 0f);
        }
    }

    void Cad()
    {
        onetime = false;
        Invoke("Caida", 3f);
    }

    void Caida()
    {
        


       GetComponent<Animator>().SetBool("Salto1", false);

       GetComponent<Animator>().SetBool("Caida", true);
       caida = false;

        Invoke("Caida2", 0.7f);

    }

    void Caida2()
    {

        GetComponent<Sapo_Controller>().enabled = true;
        GameObject.FindGameObjectWithTag("Sapo Boss").GetComponent<Sapo_Controller>().ataqueleng = true;
        GameObject.Find("Collider_Sapo2").GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<Sapo_Controller2>().enabled = false;
    }


}
