using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{

    public static AudioClip hitBall, basketSound, bgMusic;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        hitBall = Resources.Load<AudioClip>("hitBall");
        basketSound = Resources.Load<AudioClip>("basket");
        bgMusic = Resources.Load<AudioClip>("bgMusic");

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySounds(string clip)
    {

        switch (clip)
        {
            case "hitBall":
                audioSource.PlayOneShot(hitBall);
                break;
            case "basket":
                audioSource.PlayOneShot(basketSound);
                break;
            case "bgMusic":
                audioSource.PlayOneShot(bgMusic);
                break;
        }


    }


}
