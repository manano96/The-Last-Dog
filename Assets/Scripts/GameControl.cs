using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameControl : MonoBehaviour {
    public static GameControl control;
	public float TiempoLevel;
    public static int nivel = 0;
	public static int ganar = 0;
	public static int abandonado = 0;
    public static int check = 0;
	public static int muyMalo = 0;
	public static int Malo = 0;
	public static int Normal = 0;
	public static int Bueno = 0;
	public static int muyBueno = 0;
	public static int verCreditos = 0;
	public static int vez_continuar = 0;
	public static int hueso = 0;
	public static int salir = 0;
	public static int veces_morir = 0;
	public float StartTimeLevel = 0;
	public string Calificar;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        if (control == null)
            control = this;
        else if (control != this)
            Destroy(gameObject);
		TiempoLevel = Time.time;
		Analytics.CustomEvent("Nivel Alcanzado", new Dictionary<string, object>
			{
				{"tiempo", TiempoLevel},
				{"nivel", nivel},

			});
    }

    // Update is called once per frame
    void Update () {
		
	}
}
