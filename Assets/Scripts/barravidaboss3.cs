using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barravidaboss3 : MonoBehaviour {

    public Image vida;
    public Image vida2;


    private GameObject Player;
    private GameObject camion;

    private Animator caminar;
    private Rigidbody2D sapo;


    private SegumientoDEcamara camara1;
    private SegumientoDEcamara2 camara2;

    float hp, maxHp = 100f;

    // Use this for initialization
    void Start()
    {
        hp = maxHp;

        Player = GameObject.Find("Basura_Boss");
        camion = GameObject.Find("cosa");


        caminar = Player.GetComponent<Animator>();

        sapo = Player.GetComponent<Rigidbody2D>();

        camara1 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara>();
        camara2 = GameObject.Find("Main Camera").GetComponent<SegumientoDEcamara2>();

    }

    private void Update()
    {
        if (vida2.transform.localScale.x == 0)

        {
            /*caminar.SetBool("Ataque1", false);
            caminar.SetBool("Salto1", false);
            caminar.SetBool("Caida", false);*/

            Player.GetComponent<Animator>().enabled = false;


            /*Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;*/


            Player.GetComponent<CapsuleCollider2D>().enabled = false;
            
        }
    }

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp / maxHp, 1);


        if (vida.transform.localScale.x == 0)

        {
            Player.GetComponent<CapsuleCollider2D>().enabled = false;
            Player.GetComponent<BoxCollider2D>().enabled = false;
            camion.GetComponent<BoxCollider2D>().enabled = false;

            caminar.SetBool("Muerte", true);
            //Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;


            



            camara1.enabled = true;

            camara2.enabled = false;

            /*Player.GetComponent<Sapo_Controller>().enabled = false;
            Player.GetComponent<Sapo_Controller2>().enabled = false;*/



            gameObject.SetActive(false);
        }
    }
}
