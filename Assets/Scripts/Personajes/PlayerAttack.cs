using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private bool attacking = false;
	private bool ladrido = false;
	private bool trigger = false;


	private float attackTimer = 0f;
	private float attackCd = 0.5f;

	private Animator anim;
	private GameObject Player;

	public AudioClip Ladrido;
    public AudioClip Morder;


    float timeR = 0.4f;

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

            fuenteAudio.clip = Morder;

            fuenteAudio.Play();

            Invoke("ActivateNow", timeR);
		}
			



		if (Input.GetKeyDown("x") && !ladrido && !trigger)
		{
			ladrido = true;
			attackTimer = attackCd;

			fuenteAudio.clip = Ladrido;
            
			fuenteAudio.Play();
		}


		else if (Input.GetKeyDown("x") && trigger){
			ladrido = true;
			attacking = true;
			attackTimer = attackCd;

			fuenteAudio.clip = Ladrido;
			fuenteAudio.Play();

		}

		if (attacking)
		{
			if(attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			}
			else{
				attacking = false;
				GameObject.FindGameObjectWithTag("TAttack").GetComponent<BoxCollider2D>().enabled = false;
			}

		}

		anim.SetBool("Attacking", attacking);


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

	void ActivateNow()
	{
		GameObject.FindGameObjectWithTag("TAttack").GetComponent<BoxCollider2D>().enabled = true;
	}
}
