using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    private float Range;
    public float Speed;


    // Use this for initialization
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        if (Range <= 15f)
        {
            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, (transform.position.y - Enemy.transform.position.y) * Speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;


        }
    }
}
