using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atquezombie : MonoBehaviour {
    public Animator atacar;
    public Animator caminar;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            atacar.SetBool("Atack", true);
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                atacar.SetBool("Atack", false);
              

        }
        }
    }

