using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPpal : MonoBehaviour {

    


    public void BtnNuevoJuego(string nivelNuevoJuego)
    {
        SceneManager.LoadScene(nivelNuevoJuego);
        Time.timeScale = 1;

        
    }

    public void BtnSalirJuego()
    {
        Application.Quit();
    }
}
