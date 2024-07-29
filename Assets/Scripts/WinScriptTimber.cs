using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinScriptTimber : MonoBehaviour
{
    public Text ScoreTxtTimber;

    public Image WinTimber;
    public Image LoseTimber;
    public Slider TimeSliderTimber;

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

    public void WinScreenTimber()
    {
        CoinFlipTimber();
        TimeSliderTimber.value = GameObject.Find("SliderTimber").GetComponent<Slider>().value;
        ScoreTxtTimber.text = GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().pointsTimber.ToString()+"/"+ GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().pointGoalTimber.ToString();

        if (GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().pointsTimber>=GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().pointGoalTimber)
        {
                  
            WinTimber.enabled = true;
            LoseTimber.enabled = false;

        }
        else
        {
            LoseTimber.enabled = true;
            WinTimber.enabled = false;
        }
       
    }

}
