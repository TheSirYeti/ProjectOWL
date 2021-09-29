using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] private int distance;
    private bool enableCount = true;

    private void Start()
    {
        StartCoroutine(AddSteps());
    }

    IEnumerator AddSteps()
    {
        while (true)
        {
            if (enableCount)
            {
                distance += 1;
                EventManager.Trigger("UpdateUIDistance", distance);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
