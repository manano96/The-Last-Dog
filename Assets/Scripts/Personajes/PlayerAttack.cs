using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private bool ladrido = false;


    private float attackTimer = 0f;
    private float attackCd = 0.5f;

    private Animator anim;
    private GameObject Player;

    public AudioClip Ladrido;

    AudioSource fuenteAudio;


    private void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("TAttack");


    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
     if(Input.GetKeyDown("z") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            this.Player.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
     
     if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else{
                attacking = false;
                this.Player.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

        }

        anim.SetBool("Attacking", attacking);

        if (Input.GetKeyDown("x") && !ladrido)
        {
            ladrido = true;
            attackTimer = attackCd;

            fuenteAudio.clip = Ladrido;
            fuenteAudio.Play();
        }

        if (ladrido)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                ladrido = false;
            }

        }

        anim.SetBool("Ladrido", ladrido);

    }
}
