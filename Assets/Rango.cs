using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rango : MonoBehaviour {

    public int curHealth;
    public int maxHealth;

    public Animator caminar;
    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    private float Range;
    public float Speed;

    // Use this for initialization
    void Start() {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            caminar.SetBool("DentrodelRango", true);

        }

        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        if (Range <= 15f)
        {
            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;
        }
    }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                caminar.SetBool("DentrodelRango", false);

            }

            if (Range <= 15f)
            {
                Vector2 velocity = new Vector2((transform.position.x - Enemy.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
                GetComponent<Rigidbody2D>().velocity = -velocity;
            }
        }

        public void Damage(int damage)
        {
            curHealth -= damage;
        }

    }



