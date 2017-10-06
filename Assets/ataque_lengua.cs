using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque_lengua : MonoBehaviour {

    public Animator caminar;
    public GameObject sapo;

    private GameObject barravida;

    // Use this for initialization
    void Start () {

        barravida = GameObject.Find("barravida");

        caminar.SetBool("Ataque1", true);

        Invoke("Lengua1", 0.6f);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void Lengua1() {

        GetComponent<BoxCollider2D>().offset = new Vector2(-1.06f, 0.8445259f);
        GetComponent<BoxCollider2D>().size = new Vector2(0.3500824f, 0.1643929f);

        Invoke("Lengua2",0.01f);
    }

    void Lengua2()
    {

        GetComponent<BoxCollider2D>().offset = new Vector2(-1.383649f, 0.8445259f);
        GetComponent<BoxCollider2D>().size = new Vector2(0.9973807f, 0.1643929f);

        Invoke("Lengua3", 0.05f);
    }

    void Lengua3()
    {

        GetComponent<BoxCollider2D>().offset = new Vector2(-2.008512f, 0.8092775f);
        GetComponent<BoxCollider2D>().size = new Vector2(2.247106f, 0.09389615f);

        Invoke("Lengua4", 0.06f);
    }

    void Lengua4()
    {

        GetComponent<BoxCollider2D>().offset = new Vector2(-2.415471f, 0.8092775f);
        GetComponent<BoxCollider2D>().size = new Vector2(3.061025f, 0.09389615f);

        Invoke("Lengua5", 0.07f);
    }

    void Lengua5()
    {

        GetComponent<BoxCollider2D>().offset = new Vector2(-2.694249f, 0.8092775f);
        GetComponent<BoxCollider2D>().size = new Vector2(3.618581f, 0.09389615f);

        Invoke("Lengua6", 0.06f);
    }

    void Lengua6()
    {
        caminar.SetBool("Ataque1", false);

        GetComponent<BoxCollider2D>().offset = new Vector2(-1.06f, 0.8445259f);
        GetComponent<BoxCollider2D>().size = new Vector2(0.3500824f, 0.1643929f);

        sapo.GetComponent<BoxCollider2D>().enabled = true;

        GetComponent<BoxCollider2D>().enabled = false;

        GetComponent<ataque_lengua>().enabled = true;

        this.gameObject.SetActive(false);
    
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("EnemyKnockBack", transform.position.x);

            
        }



    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {


        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {


        }
    }
}
