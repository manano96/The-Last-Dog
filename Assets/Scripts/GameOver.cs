using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private GameObject barravida;

    // Use this for initialization
    void Start () {
        barravida = GameObject.Find("barravida");
        barravida.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)){

            SceneManager.LoadScene("Escena2");
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
	}
}
