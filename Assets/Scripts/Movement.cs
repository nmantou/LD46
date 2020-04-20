using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("角色状态")]
    public bool isOnGround = false;
    public bool isHurt = false;

    [Header("角色属性")]
    public float speed_Fly;
    public float speed_Jump;
    public float speed_Jump_Max;
    public float speed_Walk;

    [Header("地面检测")]
    public GameObject ground_CheckPoint;
    public float ground_CheckRadius;
    public LayerMask ground;

    private bool pressed_Jump = false;
    private Rigidbody2D rb;

    [Header("嘴部动画控制")]
    public GameObject mouth;

    Vector3 offsetMouthPosition;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        offsetMouthPosition = mouth.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressed_Jump = true;
            anim.SetTrigger("isFly");
        }

        SwitchAnim();
    }

    private void FixedUpdate()
    {
        CheckGround();
        if(!isHurt)
            Move();
    }

    private void Move()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
        }


        if(isOnGround)
        {
            float xVelocity = Input.GetAxis("Horizontal") * speed_Walk;
            rb.velocity = new Vector2(xVelocity,rb.velocity.y);
        }

        else
        {
            float xVelocity = Input.GetAxis("Horizontal") * speed_Fly;
            rb.velocity = new Vector2(xVelocity, rb.velocity.y);
        }

        if (pressed_Jump)
        {
            float yVelocity = Mathf.Max(rb.velocity.y + speed_Jump, speed_Jump_Max);
            rb.velocity = new Vector2(rb.velocity.x, yVelocity);
            AudioManager.instance.PlayFly();
            pressed_Jump = false;
        }
    }

    void CheckGround()
    {
        if (Physics2D.OverlapCircle(ground_CheckPoint.transform.position, ground_CheckRadius, ground))
        {
            isOnGround = true;
        }

        else
        {
            isOnGround = false;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(ground_CheckPoint.transform.position, ground_CheckRadius);
    }

    void SwitchAnim()
    {
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isOnGround", isOnGround);
    }

    public void MouthUp()
    {
        mouth.transform.position = new Vector3(mouth.transform.position.x, mouth.transform.position.y + 0.2f, mouth.transform.position.z);
    }

    public void MouthDown()
    {
        mouth.transform.position = transform.position + new Vector3(offsetMouthPosition.x * transform.localScale.x, offsetMouthPosition.y, offsetMouthPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if(transform.position.y >= collision.transform.GetChild(0).position.y)
            {
                collision.transform.parent.gameObject.GetComponent<Cat>().Hurt();
                rb.velocity = new Vector2(rb.velocity.x, speed_Jump * 6);
            }

            else
            {
                Debug.Log("1");
                //rb.velocity = new Vector2(speed_Jump * 4 * transform.localScale.x * (-1), 0);
                isHurt = true;
                AudioManager.instance.PlayHurt();
                anim.SetBool("isHurt", isHurt);
                rb.AddForce(new Vector2(400f,100f));
                Invoke("EndHurt", 3f);
            }
        }
    }

    void EndHurt()
    {
        isHurt = false;
        rb.gravityScale = 1;
        anim.SetBool("isHurt", isHurt);
    }
}
