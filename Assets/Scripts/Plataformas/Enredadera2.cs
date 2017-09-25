using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enredadera2 : MonoBehaviour {

    private float Trepar;
    private GameObject[] enr;
    private GameObject Player;


    // Use this for initialization
    void Start () {
		
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {

        enr = GameObject.FindGameObjectsWithTag("Enredadera");

        Trepar = Vector2.Distance(this.transform.position, Player.transform.position);
        foreach (GameObject Enredadera in enr)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && Trepar <= 1.2f)
            {
                Enredadera.GetComponent<PolygonCollider2D>().enabled = true;
            }

        }
    }
}
