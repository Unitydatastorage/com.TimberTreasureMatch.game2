using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasTimber : MonoBehaviour
{

    bool CoinFlipTimber(bool riggedTimber = false)
    {
        try
        {
            float aTimber = Time.deltaTime;

            if (riggedTimber)
            {
                return false;
            }
            else if (aTimber > 5) return true;
            else return false;
        }
        catch
        {
            return true;
        }
    }


    public void JumpTimber(string destinationTimber)
    {
        CoinFlipTimber();
        GameObject.Find("MainCameraTimber").GetComponent<SoundManagerTimber>().PlayClickTimber();
        GameObject.Find("MainCameraTimber").GetComponent<CanvasHolderTimber>().MoveTimber(destinationTimber,false);
    }


    public void JumpTimberLevel(int levelTimber)
    {
        CoinFlipTimber();
        GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().pickedLevelTimber = levelTimber;
        JumpTimber("gameTimber");
    }


    public void JumpBackTimber()
    {
        CoinFlipTimber();
        GameObject.Find("MainCameraTimber").GetComponent<SoundManagerTimber>().PlayClickTimber();
        GameObject.Find("MainCameraTimber").GetComponent<CanvasHolderTimber>().MoveBackTimber();
    }

    public void JumpOKTimber()
    {
        CoinFlipTimber();
        GameObject.Find("MainCameraTimber").GetComponent<SoundManagerTimber>().PlayClickTimber();
        GameObject.Find("MainCameraTimber").GetComponent<CanvasHolderTimber>().MoveToOKTimber();
    }

    public void CloseTimber()
    {
        CoinFlipTimber();
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }
}
