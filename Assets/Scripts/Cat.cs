using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public CatSpawner spawner;
    public GameController gameController;
    public bool isClimb = false;
    Rigidbody2D rb;
    public float moveSpeed;
    public float climbSpeed;

    public GameObject effHit;

    bool startEat = true;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!isClimb)
            Move();
        if (isClimb)
            Climb();
    }

    void Move()
    {
        if(transform.position.x > spawner.gameObject.transform.position.x)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (transform.position.x < spawner.gameObject.transform.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Hurt()
    {
        AudioManager.instance.PlayHit();
        spawner.catCount--;
        gameController.isCat = false;
        Instantiate(effHit, new Vector3(transform.position.x, transform.position.y + 0.5f, 0), Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tree")
            isClimb = true;
    }

    void Climb()
    {
        anim.SetBool("isClimb", true);
        gameController.isCat = true;
        rb.gravityScale = 0;
        if (transform.position.y < -1)
        {
            rb.velocity = new Vector2(0, climbSpeed);
        }

        else
        {
            rb.velocity = new Vector2(0, 0);
            if (startEat)
            {
                Invoke("EatBird", 10f);
                startEat = false;
            }
                
        }
    }

    void EatBird()
    {
        if(gameController.redBird != null)
        {
            gameController.IconSetDead(gameController.redBird.GetComponent<LittleBird>().birdIndex);
            gameController.deadCount++;
            Destroy(gameController.redBird);
            gameController.redBird = null;
            Invoke("EatBird", 10f);
            gameController.AddCat();
            return;
        }

        if (gameController.blueBird != null)
        {
            gameController.IconSetDead(gameController.blueBird.GetComponent<LittleBird>().birdIndex);
            gameController.deadCount++;
            Destroy(gameController.blueBird);
            gameController.blueBird = null;
            Invoke("EatBird", 10f);
            gameController.AddCat();
            return;
        }

        if (gameController.greenBird != null)
        {
            gameController.IconSetDead(gameController.greenBird.GetComponent<LittleBird>().birdIndex);
            gameController.deadCount++;
            Destroy(gameController.greenBird);
            gameController.greenBird = null;
            Invoke("EatBird", 10f);
            gameController.AddCat();
            return;
        }
    }
}
