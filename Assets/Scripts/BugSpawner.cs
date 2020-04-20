using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject bug;
    public int maxBugCount;
    public int bugCount;
    float spawnTime;

    public float spawnInterval;

    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    // Start is called before the first frame update
    void Start()
    {
        bugCount = 0;
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - spawnTime >= spawnInterval)
        {
            SpawnBug();
        }   
    }

    void SpawnBug()
    {
        if(bugCount < maxBugCount)
        {
            float xPosition = Random.Range(left.transform.position.x, right.transform.position.x);
            float yPosition = Random.Range(down.transform.position.y, up.transform.position.y);
            var bugTemp = Instantiate(bug, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            bugTemp.GetComponent<BugAction>().spawner = GetComponent<BugSpawner>();
            bugCount++;
        }

        spawnTime = Time.time;
    }
}
