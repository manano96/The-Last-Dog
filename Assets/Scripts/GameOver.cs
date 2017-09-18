using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private GameObject barravida;
    private GameObject Player;
    private GameObject Enemy;
    private GameObject Vida;

    private Animator player;

    private Rigidbody2D player1;
    private Rigidbody2D enemy1;

    private PlayerController playercontroller;
    private Rango rango;
    private PlayerAttack playerattack;
    private Bebe bebe;


    // Use this for initialization
    void Start () {
        barravida = GameObject.Find("barravida");
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Vida = GameObject.FindGameObjectWithTag("Vida");

        player1 = Player.GetComponent<Rigidbody2D>();
        enemy1 = Enemy.GetComponent<Rigidbody2D>();

        player = Player.GetComponent<Animator>();

        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        rango = GameObject.Find("Zombie1").GetComponent<Rango>();
        playerattack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        bebe = GameObject.Find("Bebe1").GetComponent<Bebe>();

        barravida.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)){

          
            gameObject.SetActive(false);
            Time.timeScale = 1f;

            playercontroller.enabled = true;
            rango.enabled = true;
            playerattack.enabled = true;
            bebe.enabled = true;


            player.SetBool("Revivir", true);
            player.SetBool("Dead", false);


            player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


            enemy1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            enemy1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


            Player.transform.position = Player.GetComponent<PlayerController>().respawnPoint;


            barravida.SetActive(true);
            barravida.SendMessage("NoDamage", 100);
        }
    }
}
