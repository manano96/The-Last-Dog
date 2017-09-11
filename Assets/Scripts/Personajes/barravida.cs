using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class barravida : MonoBehaviour {

    public Image vida;

    public GameObject perder;

    public Animator anim;

    public Rigidbody2D player;

    public Rigidbody2D enemy1;



    float hp, maxHp = 100f;

	// Use this for initialization
	void Start () {
        hp = maxHp;
    }
	
	public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp/maxHp, 1);

        if (vida.transform.localScale.x == 0)

        {

            perder.SetActive(true);

            

            anim.SetBool("Dead", true);
            anim.SetBool("Revivir", false);


            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            enemy1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }

    public void NoDamage(float amount)
    {
        hp = Mathf.Clamp(hp + amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp / maxHp, 1);

    }
}
