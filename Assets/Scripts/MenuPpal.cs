using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;


public class MenuPpal : MonoBehaviour
{
	public GameObject OcultarMouse;
    public GameObject Player;
    private SpriteRenderer spr;


    void Start()
    {

        print(GameControl.check);
        print(GameControl.nivel);

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        transform.position = new Vector2(x, y + 1f);

        
    }

    public void BtnNuevoJuego(string nivelNuevoJuego)
    {
        SceneManager.LoadScene(nivelNuevoJuego);
        Time.timeScale = 1;


    }

    public void BtnContinuar()
    {
		GameControl.vez_continuar++;
		Analytics.CustomEvent ("Continuar", new Dictionary<string, object>{
				{"vez", GameControl.vez_continuar},
				{"nivel", GameControl.nivel}
		});

        if (GameControl.nivel <= 0)
        {
            SceneManager.LoadScene("Escena2");
            Destroy(GameObject.FindWithTag("Player"));
            Instantiate(Player, transform.position, Quaternion.identity);
			Time.timeScale = 1;
        }
        if (GameControl.nivel == 1)
        {
            SceneManager.LoadScene("nivel2");
            Destroy(GameObject.FindWithTag("Player"));
            Instantiate(Player, transform.position, Quaternion.identity);
			Instantiate (OcultarMouse);
            spr = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
            spr.color= new Color32(150, 150, 255, 255);

            Time.timeScale = 1;
        }
        if (GameControl.nivel == 2)
        {
            SceneManager.LoadScene("nivel3");
            Destroy(GameObject.FindWithTag("Player"));
            Instantiate(Player, transform.position, Quaternion.identity);
			Instantiate (OcultarMouse);
            Time.timeScale = 1;
        }
        if (GameControl.nivel == 3)
        {
            SceneManager.LoadScene("nivel4");
            Destroy(GameObject.FindWithTag("Player"));
            Instantiate(Player, transform.position, Quaternion.identity);
			Instantiate (OcultarMouse);
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
