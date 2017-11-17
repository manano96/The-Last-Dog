using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Sapo_Controller : MonoBehaviour {

    private Animator caminar;


    private GameObject Player;
    private float Ladrar;
    private float Ataque1;
    private float Speed = 0.3f;
    private SpriteRenderer spr;
    private Color normal;

    private ataque_lengua barr;

    public bool ataqueleng = true;



    float timeR = 3f;

    private GameObject barravida;



    public float atackRate = 0.5F;
    private float nextAtack = 0.0F;

    public GameObject lengua;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        spr = GetComponent<SpriteRenderer>();
        normal = spr.color;

        barravida = GameObject.Find("barravida");

        caminar = this.GetComponent<Animator>();

        


        barr = GameObject.FindGameObjectWithTag("Lengua").GetComponent<ataque_lengua>();


    }

    // Update is called once per frame
    void Update()
    {
        caminar.SetBool("Caida", false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

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

        if (Ataque1 <= 5 && ataqueleng)
        {
           
                Invoke("Lengua", 0f);
            



        }}

    public void Damage(int damage)
    {

        Invoke("Colore", 0.3f);

        spr.color = Color.red;
    }

    void Colore()
    {
        spr.color = normal;
    }

    void Lengua() {

        ataqueleng = false;

        GameObject.FindGameObjectWithTag("Lengua").GetComponent<ataque_lengua>().ataquelengua = true;
        Invoke("Lengua1", 1f);

    }

    void Lengua1(){

        lengua.GetComponent<BoxCollider2D>().enabled = true;

        barr.enabled = true;

        GetComponent<Sapo_Controller>().enabled = false;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && transform.position.y > 0f)
        {
            
            Player.SendMessage("EnemyKnockBack", transform.position.x);

			Analytics.CustomEvent("Damage", new Dictionary<string, object>
				{
					{"nivel", GameControl.nivel},
					{"posicion_level_1", Player.transform.position.x},
					{"tipo", this.gameObject},

				});
            
        }
    }

}