using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detener_camara : MonoBehaviour {

    private SegumientoDEcamara camara1;
    private SegumientoDEcamara2 camara2;

    private GameObject perder;


    // Use this for initialization
    void Start() {
        camara1 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara>();
        camara2 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara2>();

        perder = GameObject.Find("VidaSapo");
        perder.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            camara1.enabled = false;

            camara2.enabled = true;

            perder.SetActive(true);

        }
    }
}
