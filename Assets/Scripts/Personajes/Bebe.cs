using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bebe : MonoBehaviour
{

    public int curHealth;
    public int maxHealth;

    public Animator caminar;
    public GameObject Enemy;
    private GameObject Player;
    private float Ladrar;
    private float Ataque;

    private bool bebe = true;

    public float Speed;

    float timeR = 3f;

    private GameObject barravida;

    public float atackRate = 0.5F;
    private float nextAtack = 0.0F;

    // Use this for initialization
    void Start()
    {
        curHealth = maxHealth;

        barravida = GameObject.Find("barravida");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = bebe;

        Player = GameObject.FindGameObjectWithTag("Player");


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



            gameObject.GetComponent<Bebe>().enabled = false;
        }

        if (Input.GetKeyDown("x"))
        {

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            caminar.SetBool("Parali", true);
            bebe = false;
            Invoke("ActivateNow", timeR);
            
        }

    }

    void ActivateNow()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        caminar.SetBool("Parali", false);
        bebe = true;
        




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

        Ataque = Vector2.Distance(Enemy.transform.position, Player.transform.position);

        if (Ataque <= 1 && bebe == true)
        {
            caminar.SetBool("Ataque", true);

            if (Time.time > nextAtack)
            {
                nextAtack = Time.time + atackRate;
                barravida.SendMessage("TakeDamage", 5);
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
        curHealth -= 35;
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

    void OnTriggerStay2D(Collider2D other)
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
        if (other.tag == "Player")
        {
            Vector2 velocity = new Vector2((transform.position.x - Enemy.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            caminar.SetBool("DentrodelRango", false);
        }
    }
}