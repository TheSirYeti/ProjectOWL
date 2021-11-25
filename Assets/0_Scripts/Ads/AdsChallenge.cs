using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsChallenge : MonoBehaviour
{
    private AdService.AdsType type;

    private void Start()
    {
#if UNITY_ANDROID
        type = AdService.AdsType.Interstitial_Android;
#endif

#if UNITY_IOS
        type = AdService.AdsType.Interstitial_iOS;
#endif
    }

    public void ShowAdChallenge()
    {
        AdService.instance.Active(type, FinishMethod, FailedMethod);
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
