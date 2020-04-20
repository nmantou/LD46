using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BugAction : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float changeTime;
    public bool canBeEat;

    public BugSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        switch (Random.RandomRange(0,8))
        {
            case 0:
                rb.velocity = new Vector2(speed, 0);
                break;

            case 1:
                rb.velocity = new Vector2(0, speed);
                break;

            case 2:
                rb.velocity = new Vector2(-speed, 0);
                break;

            case 3:
                rb.velocity = new Vector2(0, -speed);
                break;

            case 4:
                rb.velocity = new Vector2(speed,speed);
                break;

            case 5:
                rb.velocity = new Vector2(-speed, speed);
                break;

            case 6:
                rb.velocity = new Vector2(-speed, -speed);
                break;

            case 7:
                rb.velocity = new Vector2(speed, -speed);
                break;

            case 8:
                rb.velocity = new Vector2(0, 0);
                break;
        }

        transform.localScale = new Vector3(-Mathf.Sign(rb.velocity.x), 1, 1);
        Invoke("Move", changeTime);
    }

}
