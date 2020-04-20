using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject mapLeft;
    public GameObject mapRight;
    public float follow_Speed;
    public float follow_Distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance_Left = player.transform.position.x - mapLeft.transform.position.x;
        float distance_Right = mapRight.transform.position.x - player.transform.position.x;

        if(distance_Left > 13f && distance_Right > 13f)
        // FollowPlayer();
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    void FollowPlayer()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > follow_Distance)
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) <= follow_Speed)
                transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

            else
            {
                if (player.transform.position.x > transform.position.x)
                {
                    float xPosition = transform.position.x + follow_Speed;
                    transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
                }

                else
                {
                    float xPosition = transform.position.x - follow_Speed;
                    transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
                }
            }
        }
    }
}
