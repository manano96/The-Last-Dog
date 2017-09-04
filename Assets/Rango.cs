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
    private float Range;
    private float Ataque;
    public float Speed;

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
            Destroy(gameObject);
        }

        


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

        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
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
        }

        Ataque = Vector2.Distance(Enemy.transform.position, Player.transform.position);

        if (Ataque <= 1 )
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

}



