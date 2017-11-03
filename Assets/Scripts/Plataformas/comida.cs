using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class comida : MonoBehaviour {

    private GameObject barravida;
	public int num = 0;

    // Use this for initialization
    void Start () {

        barravida = GameObject.Find("barravida");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            barravida.SendMessage("NoDamage", 30);
            Destroy(gameObject);

			Analytics.CustomEvent("ComerHueso", new Dictionary<string, object>
				{
					{"nivel", GameControl.nivel},
					{"hueso", num += 1},
				});
			
        }
    }
}
