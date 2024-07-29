using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptTimber : MonoBehaviour
{
    public float TimeLeftTimber = 500;
    public bool TimerOnTimber = false;


    public Slider TimerSliderTimber;

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

    void Update()
    {
        if (TimerOnTimber)
        {
            if (TimeLeftTimber > 1)
            {
                TimeLeftTimber -= Time.deltaTime;
                UpdateTimerTimber(TimeLeftTimber);
            }
            else
            {
                CoinFlipTimber();
                TimerOnTimber = false;
                GameObject.Find("MainCameraTimber").GetComponent<CanvasHolderTimber>().MoveTimber("winTimber");
            }
        }
    }

    public void RefreshTimeTimberr()
    {
        CoinFlipTimber();
        TimeLeftTimber = 60;
        TimerOnTimber = true;
        TimerSliderTimber.value = 0;
    }
    void UpdateTimerTimber(float currentTimeTimber)
    {
        currentTimeTimber -= 1;
        CoinFlipTimber();

        TimerSliderTimber.value = 60 - TimeLeftTimber;
    }

}
