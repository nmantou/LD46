using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBird : MonoBehaviour
{
    public float stayTime;
    public GameController gameController;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("FlyAway", stayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 8f)
        {
            gameController.bigCount++;
            Destroy(gameObject);
        }
    }

    void FlyAway()
    {
        rb.velocity = new Vector2(6f, 3f);
    }
}
