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

        Enemy = GameObject.FindGameObjectWithTag("Ganar");
        Player = GameObject.FindGameObjectWithTag("Player");

        float xenemy = Enemy.transform.position.x;
        float xplayer = Player.transform.position.x;

        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        if (Range <= 0.1)
        {
            SceneManager.LoadScene("Esc");

        }
    }
}
