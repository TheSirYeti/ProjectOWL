using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class GroundStatus : Observer
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            foreach (ISubscriber sub in GetSubscribers())
            {
                sub.OnNotify("enterGround");
            }
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            foreach (ISubscriber sub in GetSubscribers())
            {
                sub.OnNotify("enterGround");
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            foreach (ISubscriber sub in GetSubscribers())
            {
                sub.OnNotify("leftGround");
            }
        }
    }
}
