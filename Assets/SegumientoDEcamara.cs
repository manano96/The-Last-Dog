using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegumientoDEcamara : MonoBehaviour {

    public GameObject follow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
