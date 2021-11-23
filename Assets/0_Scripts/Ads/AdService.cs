using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdService : MonoBehaviour
{
    
    private string id;
    private Action OnFinish, OnFailed;

    public static AdService instance;
    
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
        
        #if UNITY_ANDROID
            id = "4468869";
        #endif
    
        #if UNITY_IOS
            id = "4468868";
        #endif
        
        Advertisement.Initialize(id, false);
    }

    public void Active(AdsType nameAds, Action methodFinish, Action methodFailed)
    {
        try
        {
            if (Advertisement.IsReady(nameAds.ToString()) && !Advertisement.isShowing)
            {
                ShowOptions options = new ShowOptions();
                options.resultCallback = HandleShowResult;
                OnFailed = methodFailed;
                OnFinish = methodFinish;
                Advertisement.Show(nameAds.ToString(), options);
            }
            else
            {
                methodFailed();
            }
        }
        catch
        {
            methodFailed();
        }
    }
    
    public void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
            OnFinish?.Invoke();
        else
            OnFailed?.Invoke();
    }

    public enum AdsType
    {
        Interstitial_Android,
        Interstitial_iOS,
        Rewarded_Android,
        Rewarded_iOS
    }
}
