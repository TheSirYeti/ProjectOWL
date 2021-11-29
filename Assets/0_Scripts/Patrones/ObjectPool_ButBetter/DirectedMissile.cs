using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedMissile : MovingObjects
{
    private void Start()
    {
        StartCoroutine(StartMovement());
    }

    public override IEnumerator StartMovement()
    {
        movingCondition = true;
        StartCoroutine(ObjectMovement());
        yield return new WaitForSeconds(timeToDespawn);
        movingCondition = false;
        TurnOff(this);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            movingCondition = false;
            EventManager.Trigger("OnObstacleCollision", -1f);
            TurnOff(this);
        }
    }
    
    //For ObjectPool
    public static DirectedMissile TurnOff(DirectedMissile misisle)
    {
        misisle.gameObject.SetActive(false);
        return misisle;
    }

    public static DirectedMissile TurnOn(DirectedMissile misisle)
    {
        misisle.gameObject.SetActive(true);
        return misisle;
    }
}
