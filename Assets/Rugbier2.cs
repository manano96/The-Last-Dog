using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rugbier2 : MonoBehaviour
{

    private Animator caminar;

    private GameObject Enemy;
    private GameObject Player;
    private float Ladrar;
    private float Ataque2;
    private float Speed = 0.3f;
    private SpriteRenderer spr;

    private Rugbier2 rugbier;

    float timeR = 4f;

    private GameObject barravida;

    public float atackRate = 0.1F;
    private float nextAtack = 0.0F;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        spr = GetComponent<SpriteRenderer>();

        barravida = GameObject.Find("barravida");
        Enemy = GameObject.Find("Rugbier1");

        caminar = Enemy.GetComponent<Animator>();


        rugbier = GameObject.Find("Rugbier1").GetComponent<Rugbier2>();
    }

    // Update is called once per frame
    void Update()
    {

        Ataque2 = Vector2.Distance(Enemy.transform.position, Player.transform.position);

        caminar.SetBool("Correr", true);

        Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, Enemy.transform.position.y * -8);
        GetComponent<Rigidbody2D>().velocity = -velocity;

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        GetComponent<BoxCollider2D>().size = new Vector2(8f, 2.3f);
        GetComponent<BoxCollider2D>().offset = new Vector2(-5f, 1.223348f);




        Invoke("ActivateNow", 3);
    }

    void ActivateNow()
    {
        rugbier.enabled = false;

        Speed = 0.3f;

        caminar.SetBool("Correr", false);

        Destroy(GetComponent("Rugbier2"), 1);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.SendMessage("EnemyKnockBack", transform.position.x);

        }
    }
}






