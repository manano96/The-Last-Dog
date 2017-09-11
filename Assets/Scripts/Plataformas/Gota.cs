using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gota : MonoBehaviour {

    private GameObject barravida;
    public Animator anim;

    public float Destroygota;

    // Use this for initialization
    void Start () {
        barravida = GameObject.Find("barravida");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            barravida.SendMessage("TakeDamage", 15);
            anim.SetBool("Choque", true);
            Destroy(this.gameObject, Destroygota);

        }

        if (other.tag == "Ground")
        {
            anim.SetBool("Choque", true);
            Destroy(this.gameObject, Destroygota);

        }
    }
}
