using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transportadora : MonoBehaviour {

    private float maxSpeed = 5f;
    private float speed = 2f;

    private Rigidbody2D rb2d;

    private GameObject player;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

        rb2d = player.GetComponent<Rigidbody2D>();


    }
	
	// Update is called once per frame
	void Update () {

        
    }

    void OnCollisionStay2D(Collision2D coll)
    {
       

        if (coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.RightArrow))
        {
            maxSpeed = 2f;
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, maxSpeed, -maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
            rb2d.AddForce(Vector2.left * speed * speed);

        }
        else 
        {
            maxSpeed = 5f;
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, -maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
            rb2d.AddForce(Vector2.left * 50f * speed);

        }

        if (coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 5f;
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, maxSpeed, -maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
            rb2d.AddForce(Vector2.left * speed * speed);

        }
    }
}
