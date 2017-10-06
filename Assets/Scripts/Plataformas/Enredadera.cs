using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enredadera : MonoBehaviour {


    public float speed = 6f;
    private Animator anim;

    private GameObject[] enr;

    private float Trepar;

    private GameObject Player;

	public BoxCollider2D Collplayer;



    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = Player.GetComponent<Animator>();


    }

    // Update is called once per frame
   

     void OnTriggerStay2D(Collider2D coll)
    {



        if (Input.GetKey(KeyCode.UpArrow) && coll.tag == "Player")
        {
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", false);
            Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }


		else if (Input.GetKey(KeyCode.UpArrow) && coll.tag == "Player" | coll.tag == "Enemy2")
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

		else if (Input.GetKey(KeyCode.DownArrow) && coll.tag == "Player" | coll.tag == "Enemy2")
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
            anim.SetBool("Costado", false);
            Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }



        if (Input.GetKey(KeyCode.RightArrow) && coll.tag == "Player")
        {
            
            anim.SetBool("Costado", true);
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", false);
            
        }

		else if (Input.GetKey(KeyCode.RightArrow) && coll.tag == "Player" | coll.tag == "Enemy2")
		{

			anim.SetBool("Costado", true);
			anim.SetBool("Trepar", true);
			anim.SetBool("Quieto", false);

		}


        if (Input.GetKey(KeyCode.LeftArrow) && coll.tag == "Player")
        {

            anim.SetBool("Costado", true);
            anim.SetBool("Trepar", true);
            anim.SetBool("Quieto", false);

        }

		else if (Input.GetKey(KeyCode.LeftArrow) && coll.tag == "Player" | coll.tag == "Enemy2")
		{

			anim.SetBool("Costado", true);
			anim.SetBool("Trepar", true);
			anim.SetBool("Quieto", false);

		}



    }





	public void OnTriggerExit2D(Collider2D coll)
	{
		
		enr = GameObject.FindGameObjectsWithTag ("Enredadera");
		if (coll.tag == "Player"){	
			anim.SetBool ("Trepar", false);
		anim.SetBool ("Quieto", false);
		anim.SetBool ("Costado", false);
		Player.GetComponent<Rigidbody2D> ().gravityScale = 1f;
		foreach (GameObject Enredadera in enr) {
			Enredadera.GetComponent<PolygonCollider2D> ().enabled = false;
		}
	}
	}
}
