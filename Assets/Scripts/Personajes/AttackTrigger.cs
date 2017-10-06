using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

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

        if (col.isTrigger != true && col.CompareTag("Enemy3"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }

        if (col.isTrigger != true && col.CompareTag("Sapo Boss"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
