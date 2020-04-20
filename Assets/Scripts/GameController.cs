using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public CatSpawner catSpawner;
    public GameObject redBird;
    public GameObject greenBird;
    public GameObject blueBird;
    public GameObject camera;

    public GameObject tipHungryLeft;
    public GameObject tipHungryRight;
    public GameObject tipCatLeft;
    public GameObject tipCatRight;

    public bool isHungry = false;
    public bool isCat = false;

    public Image redIcon;
    public Image greenIcon;
    public Image yellowIcon;

    public Sprite redDead;
    public Sprite greenDead;
    public Sprite yellowDead;

    public Sprite redBig;
    public Sprite greenBig;
    public Sprite yellowBig;

    [Header("游戏状态")]
    public int deadCount = 0;
    public int bigCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        if (redBird != null && redBird.GetComponent<LittleBird>().isHungry)
        {
            isHungry = true;
        }

        else if(blueBird != null && blueBird.GetComponent<LittleBird>().isHungry)
         {
            isHungry = true;
         }

        else if (greenBird != null && greenBird.GetComponent<LittleBird>().isHungry)
        {
            isHungry = true;
        }

        else
        {
            isHungry = false;
        }

        //Debug.Log(Time.time);
        if (isHungry)
        {
            if(camera.transform.position.x > 8.6)
            {
                tipHungryLeft.SetActive(true);
            }

            else if (camera.transform.position.x < -11.7)
            {
                tipHungryRight.SetActive(true);
            }

            else
            {
                tipHungryRight.SetActive(false);
                tipHungryLeft.SetActive(false);
            }
        }

        else
        {
            tipHungryRight.SetActive(false);
            tipHungryLeft.SetActive(false);
        }

        if (isCat)
        {
            if (camera.transform.position.x > 5.7)
            {
                tipCatLeft.SetActive(true);
            }

            else if (camera.transform.position.x < -12.9)
            {
                tipCatRight.SetActive(true);
            }

            else
            {
                tipCatRight.SetActive(false);
                tipCatLeft.SetActive(false);
            }
        }

        else
        {
            tipCatRight.SetActive(false);
            tipCatLeft.SetActive(false);
        }
    }

    public void IconSetDead(int index)
    {
        switch (index)
        {
            case 0:
                redIcon.sprite = redDead;
                break;

            case 1:
                greenIcon.sprite = greenDead;
                break;

            case 2:
                yellowIcon.sprite = yellowDead;
                break;
        }
    }

    public void IconSetBig(int index)
    {
        switch (index)
        {
            case 0:
                redIcon.sprite = redBig;
                break;

            case 1:
                greenIcon.sprite = greenBig;
                break;

            case 2:
                yellowIcon.sprite = yellowBig;
                break;
        }
    }

    void CheckGameOver()
    {
        if(deadCount == 3)
        {
            SceneManager.LoadScene(3);
        }

        else if(bigCount == 3)
        {
            SceneManager.LoadScene(5);
        }

        else if (deadCount + bigCount == 3)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void AddCat()
    {
        catSpawner.maxCatCount++;
    }
}
