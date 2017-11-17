using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Podrido : MonoBehaviour
{

	public int curHealth;
	public int maxHealth;

	private Animator caminar;
	private Animator vomito;

	public GameObject shot;
	public Transform ShotSpawn;
	public float delay;
	public float fireRate;


	private GameObject Player;
	private GameObject Vo;
	private float Ladrar;
	private float Ataque;
	private SpriteRenderer spr;
	private Color normal;

	private bool podrido = true;

	public float Speed;

	float timeR = 3f;

	private GameObject barravida;

	public float atackRate = 0.8F;
	private float nextAtack = 0.0F;

	// Use this for initialization
	void Start()
	{
		curHealth = maxHealth;
		Player = GameObject.FindGameObjectWithTag("Player");
		barravida = GameObject.Find("barravida");
		caminar = this.GetComponent<Animator>();
		vomito = shot.GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
		normal = spr.color;

	}

	// Update is called once per frame
	void Update()
	{
		podrido = this.gameObject.GetComponent<BoxCollider2D>();




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



			gameObject.GetComponent<Podrido>().enabled = true;
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

		Ataque = Vector2.Distance(this.transform.position, Player.transform.position);

        if (Ataque <= 2.3f)
        {

            podrido = true;

            GetComponent<BoxCollider2D>().enabled = true;



        }

        if (Ataque <= 1.5 && podrido == true)
		{
			caminar.SetBool("Ataque", true);
			vomito.SetBool("escupir", true);



            

            if (Time.time > nextAtack)
			{
				nextAtack = Time.time + atackRate;
				barravida.SendMessage("TakeDamage", 5);
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();

				Analytics.CustomEvent("Damage", new Dictionary<string, object>
					{
						{"nivel", GameControl.nivel},
						{"posicion_level", Player.transform.position.x},
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
		curHealth -= 35;

		Invoke("Colore", 0.3f);

		spr.color = Color.red;
	}

	void Colore()
	{
		spr.color = normal;
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
			caminar.SetBool("Ataque", true);

			vomito.SetBool("escupir", true);

			InvokeRepeating ("Fire", delay, fireRate);

			podrido = true;
		}

	}

	void Fire(){
		Instantiate (shot, new Vector3(ShotSpawn.position.x, 1.105071f, ShotSpawn.position.z), ShotSpawn.rotation);
	} 



	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Vector2 velocity = new Vector2((transform.position.x - this.transform.position.x) * Speed, this.transform.position.y);
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			caminar.SetBool("DentrodelRango", false);
			caminar.SetBool("Ataque", false);
		}
	}

	void OnColliderEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && GameControl.nivel == 0)
		{

			col.SendMessage("EnemyKnockBack", transform.position.x);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>
				
				{
					{"nivel", GameControl.nivel},
					{"posicion_level_1", Player.transform.position.x},
					{"tipo", this.gameObject},
			});


		}


		if (col.gameObject.tag == "Player" && GameControl.nivel == 1)
		{

			col.SendMessage("EnemyKnockBack", transform.position.x);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>

				{
					{"nivel", GameControl.nivel},
					{"posicion_level_2", Player.transform.position.x},
					{"tipo", this.gameObject},
				});


		}


		if (col.gameObject.tag == "Player" && GameControl.nivel == 2)
		{

			col.SendMessage("EnemyKnockBack", transform.position.x);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>

				{
					{"nivel", GameControl.nivel},
					{"posicion_level_3", Player.transform.position.x},
					{"tipo", this.gameObject},
				});


		}


		if (col.gameObject.tag == "Player" && GameControl.nivel == 3)
		{

			col.SendMessage("EnemyKnockBack", transform.position.x);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>

				{
					{"nivel", GameControl.nivel},
					{"posicion_level_4", Player.transform.position.x},
					{"tipo", this.gameObject},
				});


		}



	}

}