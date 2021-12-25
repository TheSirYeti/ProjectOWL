using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    public bool amGood;

    public void OnHit()
    {
        if (amGood)
        {
            EventManager.Trigger("OnGoodTargetHit");
        }
        else
        {
            EventManager.Trigger("OnBadTargetHit");
        }
    }
}
