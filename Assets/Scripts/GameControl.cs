using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    public static GameControl control;
    public static int nivel = 0;
    public static int check = 0;
	public static int vez_continuar = 0;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        if (control == null)
            control = this;
        else if (control != this)
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
