using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class creditos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Analytics.CustomEvent("VerCreditos", new Dictionary<string, object>
			{
				{"ver", GameControl.nivel}
			});
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
