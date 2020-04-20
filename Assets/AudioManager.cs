using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioSource flySource;

    [SerializeField]
    private AudioClip getBug,eatBug,hurt,hit,fly,growth;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGetBug()
    {
        audioSource.clip = getBug;
        audioSource.Play();
    }

    public void PlayEatBug()
    {
        audioSource.clip = eatBug;
        audioSource.Play();
    }

    public void PlayHit()
    {
        audioSource.clip = hit;
        audioSource.Play();
    }

    public void PlayHurt()
    {
        audioSource.clip = hurt;
        audioSource.Play();
    }

    public void PlayGrowth()
    {
        audioSource.clip = growth;
        audioSource.Play();
    }

    public void PlayFly()
    {
        audioSource.clip = fly;
        audioSource.Play();
    }
}
