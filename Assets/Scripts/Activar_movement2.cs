using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_movement2 : MonoBehaviour {

    private GameObject Player;

    private SeguimientoDEcamara3 camara1;
    private SegumientoDEcamara2 camara2;
    private SegumientoDEcamara2 mono;

    private Animator caminar;


    // Use this for initialization
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

        camara1 = GameObject.Find("Main Camera").GetComponent<SeguimientoDEcamara3>();
        camara2 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara2>();
        mono = GameObject.Find("Mono").GetComponent<SegumientoDEcamara2>();

        caminar = GameObject.Find("Mono").GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void Movimiento()
    {

        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        camara1.enabled = false;
        camara2.enabled = true;
        mono.enabled = true;

        caminar.SetBool("Caminar", true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            Invoke("Movimiento", 1f);
        }
    }
}
