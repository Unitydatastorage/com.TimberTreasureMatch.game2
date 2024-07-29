using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CellMovementTimber : MonoBehaviour
{

    bool startTimber = false;
    Vector3 position1Timber;
    Vector3 position2Timber;

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
    public void Transition(RectTransform firstTimber, RectTransform secondTimber)
    {
        CoinFlipTimber();
        position1Timber = firstTimber.localPosition;
        position2Timber = secondTimber.localPosition;
        startTimber = true;

        if (firstTimber.localPosition != position2Timber)
        {
            firstTimber.localPosition = Vector3.Lerp(position1Timber, position2Timber, 0);
        }

        if (secondTimber.localPosition != position1Timber)
        {
            secondTimber.localPosition = Vector3.Lerp(position2Timber, position1Timber, 0);
        }
    }


}
