using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour {

    public GameObject Gotdo;

    // Use this for initialization
    void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("Gotitacayendo", 0f, 2f);

        }
    }

        void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            CancelInvoke("Gotitacayendo");

        }
        
    }

    void Gotitacayendo() {


        Instantiate(Gotdo, new Vector2(this.transform.position.x - 0.4f , this.transform.position.y - 0.7f), Quaternion.identity);
    }
}
