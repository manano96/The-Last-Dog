using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganchos : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {


        if (coll.gameObject.tag == "Player")
        {
            Invoke("Caida", 0.5f);
        }
    }

    void Caida()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
