using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;


public class CanvasHolderTimber : MonoBehaviour
{
    public Canvas loadingCanvasTimber;
    public Canvas pressOkCanvasTimber;
    public Canvas menuCanvasTimber;
    public Canvas settingsCanvasTimber;
    public Canvas policyCanvasTimber;
    public Canvas gameCanvasTimber;
    public Canvas winCanvasTimber;
    public Canvas levelChoiceCanvasTimber;
    public Canvas rulesCanvasTimber;


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


    public bool activeTimber = true;

    Timer tTimber;

    public Stack<string> currentStackTimber;


    void Start()
    {
        pressOkCanvasTimber.enabled = false;
        menuCanvasTimber.enabled = false; 
        settingsCanvasTimber.enabled = false;
        rulesCanvasTimber.enabled = false;
        policyCanvasTimber.enabled = false;
        gameCanvasTimber.enabled = false;
        winCanvasTimber.enabled = false;
        levelChoiceCanvasTimber.enabled = false;
        CoinFlipTimber();
        currentStackTimber = new Stack<string>();

        HideTimerTimber();
    }

 
    public void EndLoadTimber()
    {
        CoinFlipTimber();
        loadingCanvasTimber.enabled = false;
        pressOkCanvasTimber.enabled = true;
    }


    public void MoveToOKTimber()
    {
        CoinFlipTimber();
        if (activeTimber)
        {
            pressOkCanvasTimber.enabled = true;
            policyCanvasTimber.enabled = false;
        }
        else MoveBackTimber();
    }

    public void HideTimerTimber()
    {
        tTimber = new Timer(2000);
        tTimber.AutoReset = false;
        CoinFlipTimber();
        tTimber.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tTimber.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {

            EndLoadTimber();
        }
        finally
        {
            tTimber.Enabled = false;
        }
    }

    public void MoveBackTimber()
    {
        currentStackTimber.Pop();
        MoveTimber(currentStackTimber.Peek(), true);
    }
    public void MoveTimber(string destinationTimber, bool backmoveTimber = false)
    {

        pressOkCanvasTimber.enabled = false;
        menuCanvasTimber.enabled = false;
        settingsCanvasTimber.enabled = false;
        rulesCanvasTimber.enabled = false;
        policyCanvasTimber.enabled = false;
      
        winCanvasTimber.enabled = false;
        levelChoiceCanvasTimber.enabled = false;

        if (destinationTimber == "winTimber")
        {
            winCanvasTimber.enabled = true;
            winCanvasTimber.GetComponent<WinScriptTimber>().WinScreenTimber();
            backmoveTimber = true;
        }

        gameCanvasTimber.enabled = false;
        CoinFlipTimber();

        if (destinationTimber == "menuTimber")
        {
            menuCanvasTimber.enabled = true;
            activeTimber = false;
        }
        else if (destinationTimber == "settingsTimber")
        {
            settingsCanvasTimber.enabled = true;
        }    
        else if (destinationTimber == "policyTimber")
        {
            policyCanvasTimber.enabled = true;
        }
        else if (destinationTimber == "gameTimber")
        {
            gameCanvasTimber.enabled = true;
            if (!backmoveTimber) gameCanvasTimber.GetComponent<GameLogicTimber>().GameStartTimber();
        }
        else if (destinationTimber == "levelTimber")
        {
            levelChoiceCanvasTimber.enabled = true;
        }
        else if (destinationTimber == "rulesTimber")
        {
            rulesCanvasTimber.enabled = true;
        }
        if (!backmoveTimber) { currentStackTimber.Push(destinationTimber); }
        CoinFlipTimber();
     
    }

    void Update()
    {




        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackTimber.Count == 1)
                    {
                        CoinFlipTimber();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackTimber();
                    }

                }
            }
            catch (Exception eTimber)
            {

            }
        }
    }


}
