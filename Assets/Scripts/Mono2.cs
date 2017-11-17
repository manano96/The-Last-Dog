using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Mono2 : MonoBehaviour {

    private GameObject barravida;
    private GameObject Player;
    private SegumientoDEcamara2 camara2;
    private SegumientoDEcamara2 mono;

    private Animator caminar;

    // Use this for initialization
    void Start () {

        Player = GameObject.FindGameObjectWithTag("Player");
        barravida = GameObject.Find("barravida");

        camara2 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara2>();
        mono = GameObject.Find("Mono").GetComponent<SegumientoDEcamara2>();

        caminar = GameObject.Find("Mono").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.SendMessage("EnemyKnockBack", transform.position.x);
            barravida.SendMessage("TakeDamage", 100);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>
				{
					{"nivel", GameControl.nivel},
					{"posicion_level_2", Player.transform.position.x},
					{"tipo", this.gameObject},

				});

            caminar.SetBool("Caminar", false);

            camara2.enabled = false;
            mono.enabled = false;

        }

        if (other.gameObject.tag == "Romper")
        {
            other.gameObject.SetActive(false);

        }

    }
}
