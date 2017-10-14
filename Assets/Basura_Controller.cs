using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura_Controller : MonoBehaviour {

    private Animator caminar;


    private GameObject Player;
    private float Ataque1;
    private float Speed = 0.3f;
    private SpriteRenderer spr;
    private Color normal;

    public GameObject escupitajo;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        spr = GetComponent<SpriteRenderer>();
        normal = spr.color;

        caminar = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Ataque1 = Vector2.Distance(this.transform.position, Player.transform.position);

    }


    void FixedUpdate()
    {
    }

    public void Damage(int damage)
    {

        Invoke("Colore", 0.3f);

        spr.color = Color.red;
    }

    void Colore()
    {
        spr.color = normal;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            Invoke("Ataque", 1f);

        }
    }

    void Ataque() {

        caminar.SetBool("Vomito", true);
        Invoke("Ataque2", 0.5f);
        

    }

    void Ataque2()
    {

        if (Ataque1 < 2f){
            Player.SendMessage("EnemyKnockBack", transform.position.x);
        }

        Invoke("Ataque3", 0.5f);
    }

    void Ataque3()
    {

        caminar.SetBool("Vomito", false);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            
            Invoke("Escupitajo3", 1f);

        }
    }

    void Escupitajo()
    {


        Instantiate(escupitajo, new Vector2(371.35f, 9.13f), Quaternion.Euler(0, 0, 90));

        Invoke("Escupitajo2", 0.5f);
    }

    void Escupitajo2()
    {


        Instantiate(escupitajo, new Vector2(375.73f, 9.13f), Quaternion.Euler(0, 0, 90));
        caminar.SetBool("Escupir", false);
    }

    void Escupitajo3()
    {

        caminar.SetBool("Escupir", true);
        Invoke("Escupitajo", 1f);

    }

}