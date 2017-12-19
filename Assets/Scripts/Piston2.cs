using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Piston2 : MonoBehaviour {
    private GameObject barravida;

    private bool activar = true;

    private GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        barravida = GameObject.Find("barravida");
    }

    // Update is called once per frame
    void Update()
    {
        if (activar)
        {
            Invoke("Cerrar", 0f);
        }
    }

    void Piston1()
    {

        
        GetComponent<Animator>().SetBool("Andar", true);
        GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        Invoke("Piston20", 0.45f);
    }

    void Piston20()
    {

        GetComponent<BoxCollider2D>().offset = new Vector2(0f, -2.13f);
        Invoke("Piston3", 0.13f);
    }

    void Piston3()
    {

        GetComponent<BoxCollider2D>().offset = new Vector2(0f, -2.13f);
        activar = true;
    }

    void Cerrar()
    {
        activar = false;
        GetComponent<Animator>().SetBool("Andar", false);
        GetComponent<Animator>().SetBool("Cerrar", true);

        GetComponent<BoxCollider2D>().offset = new Vector2(0f, 1.63f);
        Invoke("Cerrar2", 1.5f);
    }

    void Cerrar2()
    {
        
        GetComponent<Animator>().SetBool("Andar", false);
        GetComponent<Animator>().SetBool("Cerrar", false);
        Invoke("Piston1", 0.15f);

    }

    void Cerrar3()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }




    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            barravida.SendMessage("TakeDamage", 15);

            Analytics.CustomEvent("Damage", new Dictionary<string, object>
				{
					{"nivel", GameControl.nivel},
					{"posicion_level", Player.transform.position.x},
					{"tipo", this.gameObject},

				});

            GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            barravida.SendMessage("TakeDamage", 15);

            Analytics.CustomEvent("Damage", new Dictionary<string, object>
				{
					{"nivel", GameControl.nivel},
					{"posicion_level", Player.transform.position.x},
					{"tipo", this.gameObject},

				});


            Invoke("Cerrar3", 1f);

        }
    }
}
