using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    private GameObject barravida;


    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }

        if (col.isTrigger != true && col.CompareTag("Enemy2"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }



        if (col.isTrigger != true && col.CompareTag("Enemy3") || col.isTrigger != true && col.CompareTag("Enemy4"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }

        if (col.isTrigger != true && col.CompareTag("parar"))
        {
            barravida = GameObject.Find("VidaSapo");
            barravida.SendMessage("TakeDamage", 10);
            col.SendMessageUpwards("Damage", dmg);
        }

        if (col.CompareTag("BasuraBoss"))
        {
            barravida = GameObject.Find("VidaSapo");
            barravida.SendMessage("TakeDamage", 10);
            col.SendMessageUpwards("Damage", dmg);
        }
    }



}
