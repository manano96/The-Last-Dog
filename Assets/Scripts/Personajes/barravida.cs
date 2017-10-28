using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class barravida : MonoBehaviour {

    private GameObject Player;
    private GameObject[] Enemy;
    private GameObject[] Enemy2;
    private GameObject[] Enemy3;
    private GameObject[] Enemy4;




    public Image vida;

    private GameObject perder;

    private Animator anim;
    private Animator anim2;
    private Animator bebeanim;
    private Animator rugbanim;
    private Animator podanim;



    private Rigidbody2D player;
    private Rigidbody2D enemy1;
    private Rigidbody2D bebe1;
    private Rigidbody2D rugbier1;
    private Rigidbody2D pod1;



    private PlayerController playercontroller;
    private Rango rango;
    private PlayerAttack playerattack;
    private Bebe bebe;
    private Rugbier rugbier;
    private ZombiePodrido pod;


    private Color spr;


    float hp, maxHp = 100f;

	// Use this for initialization
	void Start () {
        hp = maxHp;

        perder = GameObject.FindGameObjectWithTag("Finish");
        perder.SetActive(false);


        Player = GameObject.FindGameObjectWithTag("Player");
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Enemy2 = GameObject.FindGameObjectsWithTag("Enemy2");
        Enemy3 = GameObject.FindGameObjectsWithTag("Enemy3");
        Enemy4 = GameObject.FindGameObjectsWithTag("Enemy4");



        anim = Player.GetComponent<Animator>();


        player = Player.GetComponent<Rigidbody2D>(); 


        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerattack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

		spr = Player.GetComponent<SpriteRenderer>().color;


    }

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp/maxHp, 1);

		Invoke("Colore", 0.3f);

		Player.GetComponent<SpriteRenderer>().color = Color.red;

        if (vida.transform.localScale.x == 0)

        {

            perder.SetActive(true);

            foreach (GameObject Zombie1 in Enemy){

                anim2 = Zombie1.GetComponent<Animator>();
                enemy1 = Zombie1.GetComponent<Rigidbody2D>();
                rango = Zombie1.GetComponent<Rango>();

                anim2.SetBool("Ataque", false);
                anim2.SetBool("DentrodelRango", false);

                rango.enabled = false;

                Zombie1.GetComponent<BoxCollider2D>().enabled = false;
                enemy1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            foreach (GameObject Bebe1 in Enemy2)
            {

                bebeanim = Bebe1.GetComponent<Animator>();
                bebe1 = Bebe1.GetComponent<Rigidbody2D>();
                bebe = Bebe1.GetComponent<Bebe>();

                bebeanim.SetBool("Ataque", false);
                bebeanim.SetBool("DentrodelRango", false);

                bebe.enabled = false;

                Bebe1.GetComponent<BoxCollider2D>().enabled = false;
                bebe1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            foreach (GameObject Rugbier1 in Enemy3)
            {

                rugbanim = Rugbier1.GetComponent<Animator>();
                rugbier1 = Rugbier1.GetComponent<Rigidbody2D>();
                rugbier = Rugbier1.GetComponent<Rugbier>();

                rugbanim.SetBool("Ataque", false);
                rugbanim.SetBool("DentrodelRango", false);

                Rugbier1.GetComponent<BoxCollider2D>().enabled = false;
                rugbier1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            foreach (GameObject ZombiePodr in Enemy4)
            {

                podanim = ZombiePodr.GetComponent<Animator>();
                pod = ZombiePodr.GetComponent<ZombiePodrido>();

                podanim.SetBool("Ataque", false);
                podanim.SetBool("DentrodelRango", false);

                pod.enabled = false;
            }



            anim.SetBool("Dead", true);
            anim.SetBool("Revivir", false);

            playercontroller.enabled = false;
            playerattack.enabled = false;
            
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


        }
    }

    public void NoDamage(float amount)
    {
        hp = Mathf.Clamp(hp + amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp / maxHp, 1);

    }

	void Colore()
	{
		Player.GetComponent<SpriteRenderer>().color = spr;
	}
}
