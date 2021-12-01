using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class AdsChallenge : MonoBehaviour
{
    //Vemos que tipo de AD usamos
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
        //Mostramos un AD, y llamamos a los metodos de terminado y fallado.
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
