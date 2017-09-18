﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegumientoDEcamara : MonoBehaviour {

    private GameObject follow;
    public Vector2 minCamPos, maxCamPos;

	// Use this for initialization
	void Start () {
        follow = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y + 1.5f;

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);
    }
}
