using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class pinches : MonoBehaviour
{
    private GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           
                col.SendMessage("EnemyKnockBack", transform.position.x);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>
				{
					{"nivel", GameControl.nivel},
					{"posicion_level", Player.transform.position.x},
					{"tipo", this.gameObject},

				});

        }

    }


     void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Enemy2" || coll.gameObject.tag == "Enemy3")
        {

            coll.gameObject.SendMessage("Damage", 100f);


        }
    }

}

