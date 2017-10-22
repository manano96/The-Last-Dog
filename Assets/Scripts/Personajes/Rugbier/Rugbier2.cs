using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rugbier2 : MonoBehaviour
{
    public int curHealth = 100;
    public int maxHealth = 100;

    private Animator caminar;

    private GameObject Player;
    private float Ataque1;
    private float Speed = 1f;
    private SpriteRenderer spr;

    private Rugbier2 rugbier;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        spr = GetComponent<SpriteRenderer>();

        caminar = this.GetComponent<Animator>();

        curHealth = maxHealth;

        rugbier = GameObject.Find("Rugbier1").GetComponent<Rugbier2>();

        Invoke("ActivateNow", 3);
    }

    // Update is called once per frame
    void Update()
    {

        float xenemy = this.transform.position.x;
        float xplayer = Player.transform.position.x;

        Ataque1 = Vector2.Distance(this.transform.position, Player.transform.position);

        if (Ataque1 <= 15)
        {
            caminar.SetBool("Correr", true);

            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x - Time.deltaTime) * Speed, this.transform.position.y);
            GetComponent<Rigidbody2D>().velocity = -velocity;

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            GetComponent<BoxCollider2D>().size = new Vector2(8f, 2.3f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-5f, 1.223348f);
        }
        


        


        if (xenemy >= xplayer)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (xenemy <= xplayer)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if(curHealth <= 0)
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


    }

    void ActivateNow()
    {
        rugbier.enabled = false;

        Speed = 0.3f;

        caminar.SetBool("Correr", false);

        gameObject.AddComponent<Rugbier>();

        Destroy(GetComponent("Rugbier2"));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.SendMessage("EnemyKnockBack", transform.position.x);

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
}






