using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agujero : MonoBehaviour
{

    public float atackRate = 0.5F;
    private float nextAtack = 0.0F;

    private GameObject enemy;

    private GameObject barravida;

    // Use this for initialization
    void Start()
    {

        barravida = GameObject.Find("barravida");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            barravida.SendMessage("TakeDamage", 100);
            

        }

        if (col.gameObject.tag == "Enemy")
        {
            col.SendMessageUpwards("Damage", 200);
            Destroy(enemy);

        }
    }
}