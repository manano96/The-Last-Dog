using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class barravida : MonoBehaviour {

    private GameObject Player;
    private GameObject Enemy;
    private GameObject Enemy2;


    public Image vida;

    private GameObject perder;

    private Animator anim;
    private Animator anim2;
    private Animator bebeanim;

    private Rigidbody2D player;
    private Rigidbody2D enemy1;
    private Rigidbody2D bebe1;

    private PlayerController playercontroller;
    private Rango rango;
    private PlayerAttack playerattack;
    private Bebe bebe;



    float hp, maxHp = 100f;

	// Use this for initialization
	void Start () {
        hp = maxHp;

        perder = GameObject.FindGameObjectWithTag("Finish");
        perder.SetActive(false);


        Player = GameObject.FindGameObjectWithTag("Player");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Enemy2 = GameObject.FindGameObjectWithTag("Enemy2");

        anim = Player.GetComponent<Animator>();
        anim2 = Enemy.GetComponent<Animator>();
        bebeanim = Enemy2.GetComponent<Animator>();

        player = Player.GetComponent<Rigidbody2D>();
        enemy1 = Enemy.GetComponent<Rigidbody2D>();
        bebe1 = Enemy2.GetComponent<Rigidbody2D>();

        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        rango = GameObject.Find("Zombie1").GetComponent<Rango>();
        playerattack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        bebe = GameObject.Find("Bebe1").GetComponent<Bebe>();

    }

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp/maxHp, 1);

        if (vida.transform.localScale.x == 0)

        {

            perder.SetActive(true);

            

            anim.SetBool("Dead", true);
            anim.SetBool("Revivir", false);

            anim2.SetBool("Ataque", false);
            anim2.SetBool("DentrodelRango", false);

            bebeanim.SetBool("Ataque", false);
            bebeanim.SetBool("DentrodelRango", false);

            playercontroller.enabled = false;
            rango.enabled = false;
            playerattack.enabled = false;
            bebe.enabled = false;


            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            enemy1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            bebe1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


        }
    }

    public void NoDamage(float amount)
    {
        hp = Mathf.Clamp(hp + amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp / maxHp, 1);

    }
}
