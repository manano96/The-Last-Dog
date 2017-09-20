using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enredadera : MonoBehaviour {


    public float speed = 50f;
    private Animator anim;

    private GameObject[] enr;

    private float Trepar;

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
       
    }

     void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKey(KeyCode.UpArrow) && coll.tag == "Player")
        {
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", false);
            Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }


        else if (Input.GetKey(KeyCode.DownArrow) && coll.tag == "Player")
        {
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", false);
            Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }

        else
        {
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", true);
            Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        enr = GameObject.FindGameObjectsWithTag("Enredadera");
        if (coll.tag == "Player")
            {
                anim.SetBool("Trepar", false);
                anim.SetBool("Quieto", false);
                Player.GetComponent<Rigidbody2D>().gravityScale = 1f;
            foreach (GameObject Enredadera in enr)
            {
                Enredadera.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
    }
}

