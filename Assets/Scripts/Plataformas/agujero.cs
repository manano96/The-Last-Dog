using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class agujero : MonoBehaviour
{
    private GameObject Player;

    private GameObject saltarno;
    private GameObject enemy;
    private GameObject enemy2;
    private GameObject enemy3;



    private GameObject barravida;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        barravida = GameObject.Find("barravida");
        saltarno = GameObject.FindGameObjectWithTag("Tuto");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        enemy3 = GameObject.FindGameObjectWithTag("Enemy3");


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            barravida.SendMessage("TakeDamage", 100);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>
				{
					{"nivel", GameControl.nivel},
					{"posicion_level", Player.transform.position.x},
					{"tipo", this.gameObject},

				});
            

        }

        if (col.gameObject.tag == "Enemy")
        {
            saltarno.GetComponent<BoxCollider2D>().enabled = false;

            col.gameObject.SetActive(false);


        }

        if (col.gameObject.tag == "Enemy2")
        {
            col.gameObject.SetActive(false);

        }

        if (col.gameObject.tag == "Enemy3")
        {
            col.gameObject.SetActive(false);

        }

        if (col.gameObject.tag == "MonoBoss")
        {

            col.gameObject.SetActive(false);


        }
    }
}