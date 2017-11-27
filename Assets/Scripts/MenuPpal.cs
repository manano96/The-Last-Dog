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
		Analytics.CustomEvent ("NuevoJuego", new Dictionary<string, object> {
			{"nivel", GameControl.nivel}	
		});
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

	public void BtnCalificar(string escenaCalificar)
	{
		SceneManager.LoadScene(escenaCalificar);
		Time.timeScale = 1;
        Cursor.visible = true;


	}

	public void BtnCreditos(string escenaCreditos)
	{
		SceneManager.LoadScene(escenaCreditos);
		Time.timeScale = 1;
		GameControl.verCreditos++;
		Analytics.CustomEvent("VerCreditos", new Dictionary<string, object>
			{
				{"ver", GameControl.verCreditos},

			});


	}


    public void BtnMute()
    {
        AudioListener.pause = !AudioListener.pause;
    }


    public void BtnSalirJuego()
    {
        Application.Quit();
    }

	public void BtnIraMenu(string VolveraMenu)
	{
		SceneManager.LoadScene(VolveraMenu);
		Time.timeScale = 1;
	}

	public void BtnMM()
	{
		GameControl.muyMalo++;
		Analytics.CustomEvent("Calificar", new Dictionary<string, object>
			{
				{"calificacion", "Muy Malo"},
				{"nota", 1},

			});
	}

	public void BtnM()
	{
		GameControl.Malo++;
		Analytics.CustomEvent("Calificacion", new Dictionary<string, object>
			{
				{"calificacion", "Malo"},
				{"nota", 2},

			});
	}

	public void BtnNor()
	{
		GameControl.Normal++;
		Analytics.CustomEvent("Calificacion", new Dictionary<string, object>
			{
				{"calificacion", "Normal"},
				{"nota", 3},

			});
	}
	public void BtnBueno()
	{
		GameControl.Bueno++;
		Analytics.CustomEvent("Calificacion", new Dictionary<string, object>
			{
				{"calificacion", "Bueno"},
				{"nota", 4},

			});
	}
	public void BtnMB()
	{
		GameControl.muyBueno++;
		Analytics.CustomEvent("Calificacion", new Dictionary<string, object>
			{
				{"calificacion", "Muy Bueno"},
				{"nota", 5},

			});
	}

}
