using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsconderPuntero : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);

        Cursor.visible = false;

        if (GameControl.nivel >= 4)
            Cursor.visible = true;


        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
