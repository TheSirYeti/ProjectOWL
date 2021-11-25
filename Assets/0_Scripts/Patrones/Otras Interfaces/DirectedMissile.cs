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
        Destroy(gameObject);
    }
}
