using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class LevelActivatorTimber : MonoBehaviour
{

    public int currentLevelTimber = -1;

    int numberOfLevelsTimber = 21;
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

    public void ActivateButtonsTimber()
    {
        currentLevelTimber++;
        int tempTimber = currentLevelTimber;
        CoinFlipTimber(true);
        List<Button> buttonsTimber = new List<Button>();
        for (int iTimber = 2;iTimber<numberOfLevelsTimber; iTimber++)
        {
            buttonsTimber.Add(GameObject.Find("ButtonTimber" + iTimber.ToString()).GetComponent<Button>());
        }

   
        while (tempTimber > -1)
        {
            buttonsTimber[tempTimber].GetComponent<Button>().interactable = true;
            tempTimber--;
        }
        CoinFlipTimber(true);
    }
}
