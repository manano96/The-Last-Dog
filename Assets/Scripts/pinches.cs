using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinches : MonoBehaviour
{

    public float atackRate = 0.5F;
    private float nextAtack = 0.0F;

    private GameObject barravida;

    // Use this for initialization
    void Start()
    {

        barravida = GameObject.Find("barravida");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
                col.SendMessage("EnemyKnockBack", transform.position.x);

        }
    }
}

