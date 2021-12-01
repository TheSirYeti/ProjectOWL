using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID

public class SlideSlash : MonoBehaviour, IAbility
{
    IAbility next;

    public void OnSlideDown()
    {
        EventManager.Trigger("OnSlideSlashTriggered");
        next.OnSlideDown();     //Llamamos al siguiente Upgrade que este acumulado
    }

    public IAbility GetNext()
    {
        return next;
    }
    
    public void SetNext(IAbility ability)
    {
        next = ability;
    }
}
