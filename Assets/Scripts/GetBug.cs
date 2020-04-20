using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBug : MonoBehaviour
{
    public int bugCount;
    public int maxbugCount;

    public GameObject deadBug;

    public List<GameObject> bugs;
    // Start is called before the first frame update
    void Start()
    {
        bugs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bug" && bugCount < maxbugCount)
        {
            collision.gameObject.GetComponent<BugAction>().spawner.bugCount--;
            Destroy(collision.gameObject);
            bugCount++;
            AudioManager.instance.PlayGetBug();
            AddDeadBug();
        }

        if(collision.tag == "LittleMouth" && collision.transform.parent.gameObject.GetComponent<LittleBird>().isHungry && bugCount > 0)
        {
            collision.transform.parent.gameObject.GetComponent<LittleBird>().Eat();
            bugCount--;
            Destroy(bugs[0].gameObject);
            bugs.Remove(bugs[0]);
        }
    }

    void AddDeadBug()
    {
        float flip = transform.parent.localScale.x * 0.15f;
        var bug = Instantiate(deadBug, new Vector3(transform.position.x + bugCount * flip, transform.position.y, transform.position.z), new Quaternion(0,0,-60,0));
        bug.transform.SetParent(transform);
        bugs.Add(bug);
    }
}
