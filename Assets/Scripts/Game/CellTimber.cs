using System.Collections;
using UnityEngine;


public class CellTimber : MonoBehaviour
{

    public int positionXTimber;
    public int positionYTimber;
    public Sprite spriteTimber;
    public Vector3 currentPositionTimber;
    public bool needsDestructionTimber = false;



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
        GameObject.Find("MainCameraTimber").GetComponent<SoundManagerTimber>().PlayClickTimber();
        if (!GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().boolFirstTimber)
        {
            GetComponent<UnityEngine.UI.Image>().color = Color.green;
            GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().firstClickedTimber = this;
            GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().boolFirstTimber = true;
        }
        else if (!GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().boolSecondTimber)
        {
            CoinFlipTimber(true);
            GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().secondClickedTimber = this;
            GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().boolSecondTimber = true;
        }
    }

    public void RefreshSpriteTimber()
    {
        CoinFlipTimber(true);
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        GetComponent<UnityEngine.UI.Image>().sprite = spriteTimber;
    }

    public void RecolorTimber()
    {
        CoinFlipTimber(true);
        GetComponent<UnityEngine.UI.Image>().color = Color.green;
       
    }


    public void StartMoveTimber(Vector3 destinationTimber, Sprite newSpriteTimber)
    {
        CoinFlipTimber(true);
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        StartCoroutine(moveObjectTimber(destinationTimber, newSpriteTimber));
    }

    public IEnumerator moveObjectTimber(Vector3 destinationTimber, Sprite newSpriteTimber)
    {
        CoinFlipTimber(true);
        float totalMovementTimeTimber = 1f; 
        float currentMovementTimeTimber = 0f;
        while (Vector3.Distance(transform.localPosition, destinationTimber) > 0)
        {
            currentMovementTimeTimber += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(currentPositionTimber, destinationTimber, currentMovementTimeTimber / totalMovementTimeTimber);
            yield return null;
        }
        transform.localPosition = currentPositionTimber;
        spriteTimber = newSpriteTimber;
        RefreshSpriteTimber();
        CoinFlipTimber(true);
        if (GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().firstMoveFinishedTimber == false)
        {
            GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().firstMoveFinishedTimber = true;
        }
        else GameObject.Find("GameCanvasTimber").GetComponent<GameLogicTimber>().secondMoveFinishedTimber = true;

    }


    public void CellStartTimber()
    {
        CoinFlipTimber(true);
        currentPositionTimber = transform.localPosition;
        RefreshSpriteTimber();
    }

  
   
}
