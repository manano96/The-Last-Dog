using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void OnCollisionStay2D(Collision2D col){
        if (col.gameObject.tag == "Ground"){
            grounded = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Ground"){
            grounded = false;
        }
    }

    // Update is called once per frame
    void Update () {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded){
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            maxSpeed = 5f;
            speed = 125f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            maxSpeed = 3f;
            speed = 75f;
        }
    }

    void FixedUpdate()
    {

        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded){
            rb2d.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (h > 0.1f){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump){
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }


        Debug.Log(rb2d.velocity.x);
    }

    public void EnemyKnockBack(float enemyPosx)
    {
        jump = true;
        float side = Mathf.Sign(enemyPosx - transform.position.x);
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
    }

}
