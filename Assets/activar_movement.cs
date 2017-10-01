using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar_movement : MonoBehaviour {

    private GameObject Player;

    // Use this for initialization
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


        }
    }
}