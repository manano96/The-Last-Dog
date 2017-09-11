using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private GameObject barravida;
    public Animator player;

    public Rigidbody2D player1;

    public Rigidbody2D enemy1;

    public Image vida;

    // Use this for initialization
    void Start () {
        barravida = GameObject.Find("barravida");
        barravida.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)){

          
            gameObject.SetActive(false);
            Time.timeScale = 1f;

            player.SetBool("Revivir", true);

            player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


            enemy1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            enemy1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            barravida.SetActive(true);
            barravida.SendMessage("NoDamage", 100);
        }
    }
}
