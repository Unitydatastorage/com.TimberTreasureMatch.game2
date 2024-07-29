using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonsTimber : MonoBehaviour
{
    public Sprite onStateTimber1;
    public Sprite offStateTimber1;

    public Sprite onStateTimber2;
    public Sprite offStateTimber2;

    public Button buttonOnTimber;
    public Button buttonOffTimber;

    public bool isSound;
    
    public bool activeTimber=true;

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

    public void PressTimber()
    {
        activeTimber = !activeTimber;

        CoinFlipTimber(true);
        if (activeTimber)
        {
            buttonOnTimber.GetComponent<Image>().sprite=onStateTimber1;
            buttonOffTimber.GetComponent<Image>().sprite = offStateTimber2;
          
        }
        else
        {
            CoinFlipTimber(true);
            buttonOnTimber.GetComponent<Image>().sprite = offStateTimber1;
            buttonOffTimber.GetComponent<Image>().sprite = onStateTimber2;
        }

        if (isSound) GameObject.Find("MainCameraTimber").GetComponent<SoundManagerTimber>().soundIsOnTimber = activeTimber;
        else GameObject.Find("MainCameraTimber").GetComponent<SoundManagerTimber>().musicIsOnTimber = activeTimber;

    }


}

