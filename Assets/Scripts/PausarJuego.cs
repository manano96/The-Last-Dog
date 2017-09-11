using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour {

    public Transform canvas;

    private GameObject barravida;

     void Start()
    {
        barravida = GameObject.Find("barravida");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pausar();
        }
    }
        public void Pausar() {
            if (canvas.gameObject.activeInHierarchy == false) {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;

            barravida.SetActive(false);

        } else {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            barravida.SetActive(true);
        }

        }

    public void BtnSalir(string volverMenuPpal)
        {
            SceneManager.LoadScene(volverMenuPpal);
        }
    }
