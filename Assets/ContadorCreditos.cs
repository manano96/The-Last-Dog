using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ContadorCreditos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameControl.verCreditos++;
		Analytics.CustomEvent("VerCreditos", new Dictionary<string, object>
			{
				{"ver", GameControl.verCreditos},

			});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
