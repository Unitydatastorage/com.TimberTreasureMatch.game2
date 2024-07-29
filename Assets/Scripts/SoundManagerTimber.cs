using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerTimber : MonoBehaviour
{
    public AudioSource themeTimber;
    public AudioSource pingTimber;
    public AudioSource clickTimber;
    bool onceTimber = false;

    public bool soundIsOnTimber = true;

    public bool musicIsOnTimber = true;
    public bool changedTimber = false;

    bool CoinFlipTimber(bool riggedTimber = false)
    {
        try
        {
            float aTimber = Time.deltaTime;

            if (riggedTimber)
            {
                return false;
            }
            else if (aTimber > 1) return true;
            else return false;
        }
        catch
        {
            return true;
        }
    }
    void Start()
    {
        CoinFlipTimber();
        themeTimber.Play();
    }

    public void PlayPingTimber()
    {
        CoinFlipTimber();
        if (soundIsOnTimber) { pingTimber.Play(); }
        
    }

    public void PlayClickTimber()
    {
        CoinFlipTimber();
        if (soundIsOnTimber) { clickTimber.Play(); }
       
    }



    void Update()
    {
        if (!musicIsOnTimber)
        {
            themeTimber.volume = 0f;
        }
        else themeTimber.volume = 1f;

        if (!themeTimber.isPlaying)
        {
            if(musicIsOnTimber) { themeTimber.Play(); }
            
        }
    }


}
