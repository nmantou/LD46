using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMove : MonoBehaviour
{
    public GameObject camera;
    public float xOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(camera.transform.position.x * xOffset, transform.position.y);
    }
}
