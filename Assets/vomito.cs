using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vomito : MonoBehaviour {

	private GameObject barravida;
	private Animator anim;
	private GameObject Player;


	public float Destroygota;

	// Use this for initialization
	void Start () {
		barravida = GameObject.Find("barravida");
		Player = GameObject.FindGameObjectWithTag("Player");
		anim = this.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {



	}



	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			barravida.SendMessage("TakeDamage", 15);
			anim.SetBool("Choque", true);
			Destroy(this.gameObject, Destroygota);

		}

		if (other.gameObject.tag == "Enemy")
		{
			other.gameObject.SendMessage("Damage", 25f);
			anim.SetBool("Choque", true);
			Destroy(this.gameObject, Destroygota);

		}

		if (other.gameObject.tag == "Ground")
		{
			anim.SetBool("Choque", true);
			Destroy(this.gameObject, Destroygota);

		}

		if (other.gameObject.tag == "Untagged")
		{
			anim.SetBool("Choque", true);
			Destroy(this.gameObject, Destroygota);

		}
	}
}
