using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour {
 
    private GameObject Player;

    private Animator anim;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");

        anim = Player.GetComponent<Animator>();

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            anim.SetBool("Empujar", true);

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            //musica.SetActive(true);

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }

       
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            anim.SetBool("Empujar", false);

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;


           // musica.SetActive(false);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Pause();
        }

       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        

        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Enemy2" || coll.gameObject.tag == "Enemy4")
        {

            anim.SetBool("Empujar", false);

            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            coll.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            coll.gameObject.GetComponent<Animator>().SetBool("DentrodelRango", false);

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;



        }

        if (coll.gameObject.tag == "Enemy3")
        {

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;



        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Enemy2" || coll.gameObject.tag == "Enemy4")
        {

            anim.SetBool("Empujar", false);

            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            coll.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            coll.gameObject.GetComponent<Animator>().SetBool("DentrodelRango", false);

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;



        }

        if (coll.gameObject.tag == "Enemy3")
        {

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;



        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        

        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Enemy2" || coll.gameObject.tag == "Enemy4")
        {
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            coll.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            coll.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            coll.gameObject.GetComponent<Animator>().SetBool("DentrodelRango", true);

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;



        }

        if (coll.gameObject.tag == "Enemy3")
        {

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;



        }
    }
}
