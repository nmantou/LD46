using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCheck : MonoBehaviour
{
    public GameObject player;
    BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > transform.position.y)
        {
            gameObject.layer = LayerMask.NameToLayer("Ground");
            coll.enabled = true;
        }

        else
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            coll.enabled = false;
        }
    }
}
