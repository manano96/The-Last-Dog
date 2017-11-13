using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ataque_lengua : MonoBehaviour {

    public Animator caminar;
    public GameObject sapo;

    public bool ataquelengua = true;

    private GameObject barravida;

    private GameObject Player;

    // Use this for initialization
    void Start () {

        barravida = GameObject.Find("barravida");
        Player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {

        if (ataquelengua)
        {
            caminar.SetBool("Ataque1", true);

            Invoke("Lengua", 0f);
        }
    }


    void Lengua()
    {

        Invoke("Lengua1", 0.6f);
    }

    void Lengua1() {

        ataquelengua =  false;

        GetComponent<BoxCollider2D>().offset = new Vector2(-1.06f, 0.8445259f);
        GetComponent<BoxCollider2D>().size = new Vector2(0.3500824f, 0.1643929f);

        Invoke("Lengua5",0.01f);
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

        sapo.GetComponent<Sapo_Controller>().enabled = false;
        

        GetComponent<BoxCollider2D>().enabled = false;

        GetComponent<ataque_lengua>().enabled = false;

        ataquelengua = false;

        Invoke("Salto", 1.2f);

    }


    void Salto()
    {
        caminar.SetBool("Salto1", true);
        Invoke("Salto2", 0.23f);
    }

    void Salto2()
    {
        GameObject.Find("Collider_Sapo2").GetComponent<CapsuleCollider2D>().enabled = false;
        GameObject.FindGameObjectWithTag("Sapo Boss").GetComponent<Sapo_Controller2>().caida = true;
        GameObject.FindGameObjectWithTag("Sapo Boss").GetComponent<Sapo_Controller2>().onetime = true;

        sapo.GetComponent<Sapo_Controller2>().enabled = true;
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("EnemyKnockBack", transform.position.x);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>
				{
					{"nivel", GameControl.nivel},
					{"posicion_level", Player.transform.position.x},
					{"tipo", this.gameObject},

				});

            
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
