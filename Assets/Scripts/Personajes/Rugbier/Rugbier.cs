using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Rugbier : MonoBehaviour {

    public int curHealth = 100;
    public int maxHealth = 100;

    private Animator caminar;


    private GameObject Player;
    private float Ladrar;
    private float Ataque1;
    private float Ataque2;
    private float Speed = 0.3f;
    private SpriteRenderer spr;

    float timeR = 4f;

    private GameObject barravida;

    public float atackRate = 0.5F;
    private float nextAtack = 0.0F;

    private Rugbier2 rugbier;

    // Use this for initialization
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        spr = GetComponent<SpriteRenderer>();

        curHealth = maxHealth;

        barravida = GameObject.Find("barravida");
        caminar = this.GetComponent<Animator>();

        

        rugbier = GameObject.Find("Rugbier1").GetComponent<Rugbier2>();

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
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

            gameObject.GetComponent<Rugbier>().enabled = false;
        }

        if (Input.GetKeyDown("x"))
        {
            gameObject.AddComponent<Rugbier2>();
            Destroy(GetComponent("Rugbier"));
        }


        /*if (Input.GetKeyUp("x"))
        {
           

            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;

            caminar.SetBool("Correr", true);

            Speed = 1f;

            if (Ataque2 <= 1.4)
            {
                Player.SendMessage("EnemyKnockBack", transform.position.x);
            }

            Invoke("ActivateNow", timeR);
        }*/

    }

    void ActivateNow()
    {

        Speed = 0.3f;

        caminar.SetBool("Correr", false);
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
       

        if (Ataque1 <= 1.2)
        {
            caminar.SetBool("Ataque", true);
            caminar.SetBool("DentrodelRango", false);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

			if (Time.time > nextAtack && GameControl.nivel == 0)
            {
                nextAtack = Time.time + atackRate;
                barravida.SendMessage("TakeDamage", 10);
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();

				Analytics.CustomEvent("Damage", new Dictionary<string, object>
					{
						{"nivel", GameControl.nivel},
						{"posicion_level_1", Player.transform.position.x},
						{"tipo", this.gameObject},

					});

            }

			if (Time.time > nextAtack && GameControl.nivel == 1)
			{
				nextAtack = Time.time + atackRate;
				barravida.SendMessage("TakeDamage", 10);
				AudioSource audio = GetComponent<AudioSource>();
				audio.Play();

				Analytics.CustomEvent("Damage", new Dictionary<string, object>
					{
						{"nivel", GameControl.nivel},
						{"posicion_level_2", Player.transform.position.x},
						{"tipo", this.gameObject},

					});

			}

			if (Time.time > nextAtack && GameControl.nivel == 2)
			{
				nextAtack = Time.time + atackRate;
				barravida.SendMessage("TakeDamage", 10);
				AudioSource audio = GetComponent<AudioSource>();
				audio.Play();

				Analytics.CustomEvent("Damage", new Dictionary<string, object>
					{
						{"nivel", GameControl.nivel},
						{"posicion_level_3", Player.transform.position.x},
						{"tipo", this.gameObject},

					});

			}

			if (Time.time > nextAtack && GameControl.nivel == 3)
			{
				nextAtack = Time.time + atackRate;
				barravida.SendMessage("TakeDamage", 10);
				AudioSource audio = GetComponent<AudioSource>();
				audio.Play();

				Analytics.CustomEvent("Damage", new Dictionary<string, object>
					{
						{"nivel", GameControl.nivel},
						{"posicion_level_4", Player.transform.position.x},
						{"tipo", this.gameObject},

					});

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

    void Colore()
    {
        spr.color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, this.transform.position.y);
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

            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, this.transform.position.y);
            GetComponent<Rigidbody2D>().velocity = -velocity;
            caminar.SetBool("DentrodelRango", true);
        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

            Vector2 velocity = new Vector2((transform.position.x - this.transform.position.x) * Speed, (transform.position.y - this.transform.position.y) * Speed);
            caminar.SetBool("DentrodelRango", false);
        }
    }
}
