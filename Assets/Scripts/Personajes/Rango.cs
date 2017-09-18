using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rango : MonoBehaviour
{

    public int curHealth = 100;
    public int maxHealth = 100;

    private Animator caminar;


    public GameObject Enemy;
    private GameObject Player;
    private float Ladrar;
    private float Ataque1;
    private float Speed = 0.3f;

    float timeR = 3f;

    private GameObject barravida;

    public float atackRate = 0.5F;
    private float nextAtack = 0.0F;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        curHealth = maxHealth;

        barravida = GameObject.Find("barravida");
        caminar = Enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (curHealth <= 0)
        {

            caminar.SetBool("Muerte", true);
            caminar.SetBool("Ataque", false);
            caminar.SetBool("DentrodelRango", false);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            GetComponent<CapsuleCollider2D>().isTrigger = true;
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 0.5f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, 0.25f);



            GetComponent<BoxCollider2D>().size = new Vector2(0f, 0f);

            transform.gameObject.tag = "Ground";



            gameObject.GetComponent<Rango>().enabled = false;
        }

        if (Input.GetKeyDown("x")){

            GetComponent<BoxCollider2D>().size = new Vector2(8f, 1.5f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-4.5f, 0.82f);
            Invoke("ActivateNow", timeR);
        }

   }

    void ActivateNow()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(5f, 1.5f);
        GetComponent<BoxCollider2D>().offset = new Vector2(-3f, 0.82f);
    }


    void FixedUpdate()
    {
        float xenemy = Enemy.transform.position.x;
        float xplayer = Player.transform.position.x;


        if (xenemy >= xplayer)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (xenemy <= xplayer)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        Ataque1 = Vector2.Distance(Enemy.transform.position, Player.transform.position);

        if (Ataque1 <= 1)
        {
            caminar.SetBool("Ataque", true);

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
        curHealth -= 25;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;
            caminar.SetBool("DentrodelRango", true);
        }

           

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Vector2 velocity = new Vector2((transform.position.x - Enemy.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            caminar.SetBool("DentrodelRango", false);
      }
    }
}



