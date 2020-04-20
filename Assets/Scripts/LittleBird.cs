using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBird : MonoBehaviour
{
    public float eatTime;
    public float hungryTime;
    public float deadTime;
    public bool isHungry = false;
    Animator anim;

    int eatCount = 0;
    public int maxGoal;
    public GameObject bigBird;

    public GameController gameController;
    public int birdIndex;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        eatTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
        SwitchAnim();
    }

    void CheckState()
    {
        if(Time.time - eatTime >= hungryTime)
        {
            isHungry = true;
            if(Time.time - eatTime >= deadTime)
            {
                gameController.IconSetDead(birdIndex);
                gameController.AddCat();
                gameController.deadCount++;
                Destroy(gameObject);
            }
        }
    }

    void SwitchAnim()
    {
        anim.SetBool("isHungry", isHungry);
    }

    public void Eat()
    {
        if (eatCount < maxGoal)
        {
            AudioManager.instance.PlayEatBug();
            eatTime = Time.time;
            isHungry = false;
            eatCount++;
        }

        else
            GrowUp();
    }

    void GrowUp()
    {
        gameController.IconSetBig(birdIndex);
        AudioManager.instance.PlayGrowth();
        gameController.AddCat();
        Destroy(gameObject);
        var b = Instantiate(bigBird, transform.position, Quaternion.identity);
        b.GetComponent<BigBird>().gameController = gameController;
    }
}
