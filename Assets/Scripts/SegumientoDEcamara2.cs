using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegumientoDEcamara2 : MonoBehaviour
{

    private Vector3 startMarker;
    public Vector3 endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    private Animator caminar;

    void Start()
    {
        startTime = Time.time;

        startMarker = this.gameObject.transform.position;

        journeyLength = Vector3.Distance(startMarker, endMarker);

        caminar = GameObject.Find("Mono").GetComponent<Animator>();
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

        if(transform.position == endMarker)
        {
            caminar.SetBool("Caminar", false);
        }
    }


}

