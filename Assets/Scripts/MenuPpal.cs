using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPpal : MonoBehaviour {

    public GameObject Player;

    void Start()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("Playery");

        transform.position = new Vector2(x, y);
    }

    public void BtnNuevoJuego(string nivelNuevoJuego)
    {
        SceneManager.LoadScene(nivelNuevoJuego);
        Time.timeScale = 1;

        
    }

    public void BtnContinuar() {

        if (GameControl.nivel < 3) {
            SceneManager.LoadScene("Escena2");
            Instantiate(Player, transform.position, Quaternion.identity);
            Time.timeScale = 1;
        }
        if (GameControl.nivel >= 3 && GameControl.nivel < 6){
            SceneManager.LoadScene("nivel2");
            Instantiate(Player, new Vector2(0f, 0f), Quaternion.identity);
            Time.timeScale = 1;
        }
        if (GameControl.nivel >= 6 && GameControl.nivel < 9){
            SceneManager.LoadScene("nivel3");
            Instantiate(Player, new Vector2(0f, 0f), Quaternion.identity);
            Time.timeScale = 1;
        }
        
    }

    public void BtnMute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

 
    public void BtnSalirJuego()
    {
        Application.Quit();
    }
}
