using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comida : MonoBehaviour {

    private GameObject barravida;

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

            barravida.SendMessage("NoDamage", 15);
            Destroy(gameObject);
        }
    }
}
