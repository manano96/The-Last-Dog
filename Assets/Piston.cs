using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour {

    private GameObject barravida;

    // Use this for initialization
    void Start () {

        barravida = GameObject.Find("barravida");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            


            Invoke("Piston1", 0.4f);

        }
    }

    void Piston1() {

        GetComponent<Animator>().SetBool("Andar", true);
        GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        GetComponent<CapsuleCollider2D>().enabled = false;
        Invoke("Piston2", 0.11f);
    }

    void Piston2()
    {

        GetComponent<BoxCollider2D>().offset = new Vector2(0f, -2.13f);
        Invoke("Piston3", 0.13f);
    }

    void Piston3()
    {

        GetComponent<BoxCollider2D>().offset = new Vector2(0f, -2.13f);
        Invoke("Cerrar", 0.15f);
    }

    void Cerrar()
    {
        GetComponent<Animator>().SetBool("Andar", false);
        GetComponent<Animator>().SetBool("Cerrar", true);

        GetComponent<BoxCollider2D>().offset = new Vector2(0f, 1.63f);
        Invoke("Cerrar2", 1.5f);
    }

    void Cerrar2()
    {
        GetComponent<Animator>().SetBool("Andar", false);
        GetComponent<Animator>().SetBool("Cerrar", false);
        GetComponent<CapsuleCollider2D>().enabled = true;
    }

    void Cerrar3()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }




    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            coll.gameObject.SendMessage("EnemyKnockBack", transform.position.x);

            GetComponent<BoxCollider2D>().enabled = false;

            GetComponent<Piston>().enabled = false;

        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            coll.gameObject.SendMessage("EnemyKnockBack", transform.position.x);

            
            Invoke("Cerrar3", 1f);

        }
    }
}
