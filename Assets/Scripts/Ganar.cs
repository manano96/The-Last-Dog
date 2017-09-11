using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{

    private float Range;

    private GameObject Enemy;
    private GameObject Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            SceneManager.LoadScene("Escena2");
            Time.timeScale = 1f;
        }

    }
}
