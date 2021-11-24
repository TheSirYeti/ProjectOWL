using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsChallenge : MonoBehaviour
{
    public void ShowAdChallenge()
    {
        AdService.instance.Active(AdService.AdsType.Interstitial_Android, FinishMethod, FailedMethod);
    }

    public void FinishMethod()
    {
        EventManager.Trigger("OnAdFinished");
    }

    public void FailedMethod()
    {
        Time.timeScale = 1f;
        EventManager.Trigger("OnAdFailed");
    }
}
