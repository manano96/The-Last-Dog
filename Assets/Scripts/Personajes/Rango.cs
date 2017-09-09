using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rango : MonoBehaviour
{

    public int curHealth;
    public int maxHealth;

    public Animator caminar;
    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    /*private float Range;*/
    private float Ladrar;
    private float Ataque;
    public float Speed;

    float timeR = 3f;

    public Rigidbody2D rb;

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

        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");


        if (curHealth <= 0)
        {

            caminar.SetBool("Muerte", true);
            caminar.SetBool("Ataque", false);
            caminar.SetBool("DentrodelRango", false);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

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

        /*Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        if (Range <= 5)
        {
            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;
            caminar.SetBool("DentrodelRango", true);
            
        }
        else
        {

            Vector2 velocity = new Vector2((transform.position.x - Enemy.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;
            caminar.SetBool("DentrodelRango", false);
        }*/

        Ataque = Vector2.Distance(Enemy.transform.position, Player.transform.position);

        if (Ataque <= 1)
        {
            caminar.SetBool("Ataque", true);

            if (Time.time > nextAtack)
            {
                nextAtack = Time.time + atackRate;
                barravida.SendMessage("TakeDamage", 15);
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
        curHealth -= damage;
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



