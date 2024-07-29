using System;

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class GameLogicTimber : MonoBehaviour
{

    public CellTimber firstClickedTimber;
    public bool boolFirstTimber = false;

    public CellTimber secondClickedTimber;
    public bool boolSecondTimber = false;
    System.Random rTimber = new System.Random();

    bool checkValueTimber = true;

    public Sprite sprite1Timber;
    public Sprite sprite2Timber;
    public Sprite sprite3Timber;
    public Sprite sprite4Timber;

    bool checkOverTimber = true;

    public Text scoreTextTimber;

    int horizonValueTimber = 5;
    int cellAmountTimber = 31;

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

    public bool firstMoveFinishedTimber =false;
    public bool secondMoveFinishedTimber = false;


   
    bool destructionHappenedTimber = false;

    public int pointsTimber = 0;
    public int pointGoalTimber = 500;
    int increaseTimber = 15;
    public int pickedLevelTimber = 0;
    bool pointCountTimber = false;


    List<int> horizontalTimber;
    List<int> verticalTimber;

    public async Task TryCheckTimber()
    {
        checkOverTimber = false;
        CoinFlipTimber(true);

        for (int jTimber = 1; jTimber < cellAmountTimber; jTimber++)
        {

            if (horizontalTimber.Contains(jTimber)){
                
                if ((GameObject.Find("GamePiece" + (jTimber + 1).ToString() + "Timber").GetComponent<CellTimber>().spriteTimber.GetInstanceID() == GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().spriteTimber.GetInstanceID()) && (GameObject.Find("GamePiece" + (jTimber - 1).ToString() + "Timber").GetComponent<CellTimber>().spriteTimber.GetInstanceID() == GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().spriteTimber.GetInstanceID()))
                {
                    if (!GameObject.Find("GamePiece" + (jTimber - 1).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber)
                    {
                        GameObject.Find("GamePiece" + (jTimber - 1).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber = true;
                        if (pointCountTimber)
                            pointsTimber += increaseTimber;
                    }
                    if (!GameObject.Find("GamePiece" + (jTimber).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber)
                    {
                        GameObject.Find("GamePiece" + (jTimber).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber = true;
                        if (pointCountTimber)
                            pointsTimber += increaseTimber;
                    }
                    if (!GameObject.Find("GamePiece" + (jTimber + 1).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber)
                    {
                        GameObject.Find("GamePiece" + (jTimber + 1).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber = true;
                        if (pointCountTimber)
                            pointsTimber += increaseTimber;
                    }
                
                }
            }
            CoinFlipTimber(true);
            if (verticalTimber.Contains(jTimber))
            {
             
                if ((GameObject.Find("GamePiece" + (jTimber + horizonValueTimber).ToString() + "Timber").GetComponent<CellTimber>().spriteTimber.GetInstanceID() == GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().spriteTimber.GetInstanceID()) && (GameObject.Find("GamePiece" + (jTimber - horizonValueTimber).ToString() + "Timber").GetComponent<CellTimber>().spriteTimber.GetInstanceID() == GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().spriteTimber.GetInstanceID()))
                {
                    if (!GameObject.Find("GamePiece" + (jTimber - horizonValueTimber).ToString()+"Timber").GetComponent<CellTimber>().needsDestructionTimber)
                    {
                        GameObject.Find("GamePiece" + (jTimber - horizonValueTimber).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber = true;
                        if (pointCountTimber)
                            pointsTimber += increaseTimber;
                    }
                    if (!GameObject.Find("GamePiece" + (jTimber).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber)
                    {
                        GameObject.Find("GamePiece" + (jTimber).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber = true;
                        if (pointCountTimber)
                            pointsTimber += increaseTimber;
                    }
                    if (!GameObject.Find("GamePiece" + (jTimber + horizonValueTimber).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber)
                    {
                        GameObject.Find("GamePiece" + (jTimber + horizonValueTimber).ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber = true;
                        if (pointCountTimber)
                            pointsTimber += increaseTimber;
                    }
              
                }

            }


        }
        bool happenedTimber = false;

        for (int jTimber = 1; jTimber < cellAmountTimber; jTimber++)
        {
            CoinFlipTimber(true);
            if (GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber)
            {

                GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().RecolorTimber();
                happenedTimber = true;

            }
        }

        if(happenedTimber&&pointCountTimber) await Task.Delay(1000);


        for (int jTimber = 1; jTimber < cellAmountTimber; jTimber++)
        {
            CoinFlipTimber(true);
            if ( GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber){
                GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().needsDestructionTimber = false;
                NewDestroyTimber(GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>(), jTimber);
                
            }
        }
        CoinFlipTimber(true);
        if (happenedTimber) { destructionHappenedTimber = true;
            if (pointCountTimber&&checkValueTimber) GameObject.Find("MainCameraTimber").GetComponent<SoundManagerTimber>().PlayPingTimber();
        }
        else destructionHappenedTimber= false;
        CoinFlipTimber(true);
        scoreTextTimber.text = pointsTimber.ToString() + "/" + pointGoalTimber.ToString();
        checkOverTimber = true;
    }


    public void NewDestroyTimber(CellTimber targetTimber,int numberTimber)
    {
        if (numberTimber < (horizonValueTimber+1))
        {        
            targetTimber.spriteTimber = RandomSpriteTimber();
        }
        else
        {
            targetTimber.spriteTimber = GameObject.Find("GamePiece" + (numberTimber - horizonValueTimber).ToString() + "Timber").GetComponent<CellTimber>().spriteTimber;
            NewDestroyTimber(GameObject.Find("GamePiece" + (numberTimber - horizonValueTimber).ToString() + "Timber").GetComponent<CellTimber>(), numberTimber - horizonValueTimber);
        }
        CoinFlipTimber(true);
    }

    public void GameStartTimber()
    {
        pointCountTimber = false;
        horizontalTimber = new List<int>
        {2,3,4,7,8,9,12,13,14,17,18,19,22,23,24,27,28,29};

        verticalTimber = new List<int>
        {6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
        CoinFlipTimber(true);


        CoinFlipTimber(true);

        for (int jTimber = 1; jTimber < cellAmountTimber; jTimber++)
        {
            GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().spriteTimber = RandomSpriteTimber();
            GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().CellStartTimber();

        }

        checkValueTimber = true;
        GameObject.Find("GameCanvasTimber").GetComponent<TimerScriptTimber>().RefreshTimeTimberr();

        pointsTimber = 0;
        pointGoalTimber+= pickedLevelTimber * 5;
        scoreTextTimber.text = "0/"+pointGoalTimber.ToString();

        CoinFlipTimber(true);

        BigGameCheckTimber();
        pointCountTimber = true;
    }
    public Sprite RandomSpriteTimber()
    {
        CoinFlipTimber(true);
        Sprite tempSpriteTimber;
        int rIntTimber = rTimber.Next(0, 4);
        if (rIntTimber == 0) tempSpriteTimber = sprite1Timber;
        else if (rIntTimber == 1) tempSpriteTimber = sprite2Timber;
        else if (rIntTimber == 2) { tempSpriteTimber = sprite3Timber;
            CoinFlipTimber(true);
        }
        else tempSpriteTimber = sprite4Timber;
         return tempSpriteTimber;
    }

    void SwapTimber()
    {
     
        if ((Math.Abs(firstClickedTimber.positionXTimber - secondClickedTimber.positionXTimber) +Math.Abs(firstClickedTimber.positionYTimber - secondClickedTimber.positionYTimber))==1)
        {
            Vector3 firstTempTimber = secondClickedTimber.currentPositionTimber;
            Vector3 secondTempTimber = firstClickedTimber.currentPositionTimber;
            Sprite temp1 = secondClickedTimber.spriteTimber;
            Sprite temp2 = firstClickedTimber.spriteTimber;
            firstClickedTimber.StartMoveTimber(firstTempTimber, temp1);
            secondClickedTimber.StartMoveTimber(secondTempTimber, temp2);
            CoinFlipTimber(true);
        }
        else
        {
            firstClickedTimber.RefreshSpriteTimber();
            firstClickedTimber = null;
            secondClickedTimber = null;
            boolFirstTimber = false;
            boolSecondTimber = false;
        }
        CoinFlipTimber(true);
    }

 


    public async void BigGameCheckTimber()
    {
        await TryCheckTimber();

        if(!pointCountTimber)
        while (destructionHappenedTimber)
        {
            TryCheckTimber();
            CoinFlipTimber(true);
        }
        for (int jTimber = 1; jTimber < cellAmountTimber; jTimber++)
        {
            GameObject.Find("GamePiece" + jTimber.ToString() + "Timber").GetComponent<CellTimber>().RefreshSpriteTimber();
            CoinFlipTimber(true);

        }
       
        if (pointCountTimber)
            if ((destructionHappenedTimber)&&(checkValueTimber))
             {
                Invoke("BigGameCheckTimber", 1);
                //BigGameCheckTimber();
                    }

        //scoreTextTimber.text = pointsTimber.ToString()+"/"+pointGoalTimber.ToString();
    }



    void Update()
    {
        if (GameObject.Find("MainCameraTimber").GetComponent<CanvasHolderTimber>().gameCanvasTimber.enabled)
        {
            if ((pointsTimber>=pointGoalTimber)&&checkOverTimber)
            {
                checkValueTimber = false;
                CoinFlipTimber(true);
                GameObject.Find("LevelChoiceCanvasTimber").GetComponent<LevelActivatorTimber>().ActivateButtonsTimber();
                GameObject.Find("MainCameraTimber").GetComponent<CanvasHolderTimber>().MoveTimber("winTimber");
            }
        }

        if (boolFirstTimber && boolSecondTimber)
        {
            CoinFlipTimber(true);
            boolFirstTimber = false;
            boolSecondTimber = false;
            if (firstClickedTimber != secondClickedTimber) SwapTimber();
            else firstClickedTimber.RefreshSpriteTimber();         
           
        }

        if (firstMoveFinishedTimber && secondMoveFinishedTimber)
        {
            firstMoveFinishedTimber = false;
            secondMoveFinishedTimber = false;
            BigGameCheckTimber();
        }
    }
}
