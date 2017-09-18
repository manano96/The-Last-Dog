using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    private bool movement = true;
    private SpriteRenderer spr;
    private GameObject Enredadera;
    private GameObject Player;
    private float Trepar;

    private GameObject barravida;

    public Vector3 respawnPoint;

    private Enredadera enredadera;


    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        barravida = GameObject.Find("barravida");

        respawnPoint = transform.position;
        enredadera = GameObject.Find("Enredaderax").GetComponent<Enredadera>();


    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Enredadera = GameObject.Find("Enredaderax");
        Player = GameObject.FindGameObjectWithTag("Player");

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        float xenred = Enredadera.transform.position.x;
        float xplayer = Player.transform.position.x;

        if (Input.GetKeyDown(KeyCode.Space) && grounded && transform.position.y > -0.3f)
        {
            jump = true;

            anim.SetBool("Agacharse", false);

            GetComponent<BoxCollider2D>().size = new Vector2(1.06f, 0.9333333f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0.07f, 0.4666667f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxSpeed = 5f;
            speed = 125f;

            anim.SetBool("Agacharse", false);

            GetComponent<BoxCollider2D>().size = new Vector2(1.06f, 0.9333333f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0.07f, 0.4666667f);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxSpeed = 3f;
            speed = 75f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("Agacharse", true);

            GetComponent<BoxCollider2D>().size = new Vector2(1.06f, 0.33f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.17f);

            jump = false;

            maxSpeed = 1.5f;
            speed = 40f;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("Agacharse", false);

            GetComponent<BoxCollider2D>().size = new Vector2(1.06f, 0.9333333f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0.07f, 0.4666667f);

            maxSpeed = 3f;
            speed = 75f;
        }

        Trepar = Vector2.Distance(Enredadera.transform.position, Player.transform.position);

        if (Input.GetKeyDown(KeyCode.UpArrow) && Trepar < 2.5f && Trepar > -2.5f)
        {
            enredadera.enabled = true;
        }


    }

    void FixedUpdate()
    {

        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
            anim.SetBool("Revivir", false);

        }

        float h = Input.GetAxis("Horizontal");

        if (!movement) h = 0;

        rb2d.AddForce(Vector2.right * speed * h);


        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

       

      

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }




        Debug.Log(rb2d.velocity.x);
        Debug.Log(rb2d.velocity.y);

    }

    public void EnemyKnockBack(float enemyPosx)
    {
        barravida.SendMessage("TakeDamage", 15);

        jump = true;

        float side = Mathf.Sign(enemyPosx - transform.position.x);

        rb2d.AddForce(Vector2.left * side * jumpPower);

        movement = false;
        Invoke("EnableMovement", 0.8f);

        spr.color = Color.red;

    }

    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Checkpoints") {
            respawnPoint = other.transform.position;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enredadera")
        {
            enredadera.enabled = false;
        }
    }

}
