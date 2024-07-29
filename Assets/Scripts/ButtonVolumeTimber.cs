using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVolumeTimber : MonoBehaviour
{
    public bool isSound = true;
    public bool isActive = true;
    public Button counterpartTimber;

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

    public void OnClickTimber()
    {
        if (!isActive)
        {
            CoinFlipTimber();
            isActive = true;
            counterpartTimber.GetComponent<ButtonVolumeTimber>().isActive = false;
            if (isSound)
            {
                GameObject.Find("SoundNameTimber").GetComponent<SoundButtonsTimber>().PressTimber();
            }
            else
            {
                CoinFlipTimber();
                GameObject.Find("MusicNameTimber").GetComponent<SoundButtonsTimber>().PressTimber();
            }
        }
    }

}
