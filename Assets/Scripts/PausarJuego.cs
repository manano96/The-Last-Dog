using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarJuego : MonoBehaviour {

    public Transform canvas;

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
            } else {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;

            }

        }
    }
