using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

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
            Cursor.visible = true;
            barravida.SetActive(false);

        } else {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            barravida.SetActive(true);
            Cursor.visible = false;
        }

        }

    public void BtnSalir(string volverMenuPpal)
        {
            SceneManager.LoadScene(volverMenuPpal);
			Destroy(GameObject.FindWithTag("Player"));
			Destroy(GameObject.Find("OcultarMouse"));
			GameControl.abandonado++;
			Analytics.CustomEvent("Abandonar", new Dictionary<string, object>
			{
				{"nivel", GameControl.abandonado},

			});
        }
    }
