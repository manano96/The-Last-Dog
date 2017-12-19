using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class Llegar : MonoBehaviour {

	public string escena;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(GameObject.FindWithTag("Player"));

            SceneManager.LoadScene(escena);
            GameControl.ganar ++;
            GameControl.nivel++;


            Analytics.CustomEvent("Ganar", new Dictionary<string, object>
				{
					{"nivel", GameControl.ganar},

				});

        }
    }
}
