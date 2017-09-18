using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enredadera : MonoBehaviour {


    public float speed = 50f;
    private Animator anim;

    private GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
      

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.UpArrow))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", false);
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;

        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.DownArrow ))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", false);
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;

        }
        else 
        {

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", true);


        }


    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Trepar", false);
            anim.SetBool("Quieto", false);
            other.GetComponent<Rigidbody2D>().gravityScale = 1f;
            this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
          

        }
    }
}

