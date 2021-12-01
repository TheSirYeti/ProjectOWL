using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID

public class NormalSlide : MonoBehaviour, IAbility
{
    IAbility next;

    public void OnSlideDown()
    {
        SoundManager.instance.PlaySound(SoundID.SLIDE);
        //No llamamos al next ya que es el slide base, pero dejamos la variable por si se trata de algun upgrade
        //que se active luego de determinado tiempo (no implementado, pero lo dejamos para el futuro).
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
