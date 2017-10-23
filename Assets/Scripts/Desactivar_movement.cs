using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar_movement : MonoBehaviour {


    private SegumientoDEcamara camara1;
    private SegumientoDEcamara2 camara2;
    private SegumientoDEcamara2 mono;

    private Animator caminar;


    // Use this for initialization
    void Start()
    {



        camara1 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara>();
        camara2 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara2>();
        mono = GameObject.Find("Mono").GetComponent<SegumientoDEcamara2>();

        caminar = GameObject.Find("Mono").GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            camara1.enabled = true;
            camara2.enabled = false;
            mono.enabled = false;

            caminar.SetBool("Caminar", false);
            caminar.SetBool("Caer", true);

        }
    }
}