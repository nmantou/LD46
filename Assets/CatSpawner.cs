using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public int maxCatCount;
    public int catCount = 0;
    public float spawnIntervalUp;
    public float spawnIntervalDown;
    public GameObject cat;
    public GameObject left;
    public GameObject right;
    float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCat", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCat()
    {
        if(catCount < maxCatCount)
        {
            float xPosition = 0;
            switch (Random.Range(0, 2))
            {
                case 0:
                    xPosition = left.transform.position.x;
                    break;
                case 1:
                    xPosition = right.transform.position.x;
                    break;
            }
            
            var catTemp = Instantiate(cat, new Vector3(xPosition, transform.position.y, 0), Quaternion.identity);
            catTemp.GetComponent<Cat>().spawner = GetComponent<CatSpawner>();
            catTemp.GetComponent<Cat>().gameController = GameObject.Find("GameController").GetComponent<GameController>();
            catCount++;
        }

        float spawnInterval = Random.Range(spawnIntervalDown, spawnIntervalUp);
        Invoke("SpawnCat", spawnInterval);
    }
}
