using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sombra : MonoBehaviour {

    private GameObject Player;

    private float Speed = 10f;

    // Use this for initialization
    void Start () {

        Player = GameObject.FindGameObjectWithTag("Sapo Boss");

    }
	
	// Update is called once per frame
	void Update () {

        float xenemy = this.transform.position.x;
        float xplayer = Player.transform.position.x;

        Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, this.transform.position.y);
        GetComponent<Rigidbody2D>().velocity = -velocity;

        


        if (xenemy >= xplayer)
        {
            transform.localScale = new Vector2(1f, 1f);
        }

        if (xenemy <= xplayer)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
}
