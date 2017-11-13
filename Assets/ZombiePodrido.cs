using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePodrido : MonoBehaviour {

    public int curHealth = 100;
    public int maxHealth = 100;

    private Animator caminar;

    public GameObject escupiSpawner;

    private GameObject Player;
    private float Ladrar;
    private float Ataque1;
    private float Speed = 0.3f;
    private SpriteRenderer spr;
    private Color normal;

    float timeR = 3f;

    private GameObject barravida;

    public float atackRate = 0.5F;
    private float nextAtack = 0.0F;

    public GameObject Escupitajo;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        spr = GetComponent<SpriteRenderer>();
        normal = spr.color;

        curHealth = maxHealth;

        barravida = GameObject.Find("barravida");
        caminar = this.GetComponent<Animator>();
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



            gameObject.GetComponent<ZombiePodrido>().enabled = false;
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

        Ataque1 = Vector2.Distance(transform.position, Player.transform.position);


        if (Ataque1 <= 6)
        {
            caminar.SetBool("Ataque", true);
            caminar.SetBool("DentrodelRango", false);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

            if (Time.time > nextAtack)
            {
                nextAtack = Time.time + atackRate;

                Instantiate(Escupitajo, escupiSpawner.transform.position, Escupitajo.transform.rotation);
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                curHealth -= 50;
                Invoke("Colore", 0.3f);

                spr.color = Color.red;
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

        Invoke("Colore", 0.3f);

        spr.color = Color.red;
    }


    void Colore() {
        spr.color = normal;
    }

}
