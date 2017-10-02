using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProhibidoSaltar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = new Vector2(other.transform.position.x, -0.1026647f);
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


        }
    }
}
