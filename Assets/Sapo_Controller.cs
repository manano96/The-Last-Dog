using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo_Controller : MonoBehaviour {

    public int curHealth = 100;
    public int maxHealth = 100;

    private Animator caminar;


    private GameObject Player;
    private float Ladrar;
    private float Ataque1;
    private float Speed = 0.3f;
    private SpriteRenderer spr;
    private Color normal;

    private SegumientoDEcamara camara1;
    private SegumientoDEcamara2 camara2;

    private ataque_lengua barr;


    float timeR = 3f;

    private GameObject barravida;
    private GameObject basura;


    public float atackRate = 0.5F;
    private float nextAtack = 0.0F;

    public GameObject lengua;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        spr = GetComponent<SpriteRenderer>();
        normal = spr.color;

        curHealth = maxHealth;

        barravida = GameObject.Find("barravida");
        basura = GameObject.FindGameObjectWithTag("basura");

        caminar = this.GetComponent<Animator>();

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation ;

        camara1 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara>();
        camara2 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara2>();
        barr = GameObject.FindGameObjectWithTag("Lengua").GetComponent<ataque_lengua>();


    }

    // Update is called once per frame
    void Update()
    {

        if (curHealth <= 0)
        {

            //caminar.SetBool("Muerte", true);
            //caminar.SetBool("Ataque", false);
            //caminar.SetBool("DentrodelRango", false);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;

            basura.GetComponent<BoxCollider2D>().enabled = false;

            camara1.enabled = true;

            camara2.enabled = false;

            gameObject.GetComponent<Sapo_Controller>().enabled = false;
        }
    }


    void FixedUpdate()
    {
        float xenemy = this.transform.position.x;
        float xplayer = Player.transform.position.x;


        if (xenemy >= xplayer)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (xenemy <= xplayer)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        Ataque1 = Vector2.Distance(this.transform.position, Player.transform.position);

        if (Ataque1 <= 1)
        {
            

            if (Time.time > nextAtack)
            {
                nextAtack = Time.time + atackRate;
                barravida.SendMessage("TakeDamage", 10);
            }
        }
        else
        {
            caminar.SetBool("Ataque", false);

            nextAtack = Time.time + atackRate;

        }

    }

    public void Damage(int damage)
    {
        curHealth -= 10;

        Invoke("Colore", 0.3f);

        spr.color = Color.red;
    }

    void Colore()
    {
        spr.color = normal;
    }

    void Lengua() {
        lengua.GetComponent<BoxCollider2D>().enabled = true;

        barr.enabled = true;

        GetComponent<BoxCollider2D>().enabled = false;


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("Lengua", 1f);



        }



    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

           
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

           
        }
    }
}