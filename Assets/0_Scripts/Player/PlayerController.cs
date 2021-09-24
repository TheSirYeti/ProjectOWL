using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Action artificialUpdate;
    private float minimumSwipeTriggerValue;

    private void Start()
    {
        SwipeManager.instance.OnEndTouch += CheckInputs;
    }

    public void CheckInputs(Vector2 position)
    {
        if (position.x >= minimumSwipeTriggerValue)
        {
            //transform.position += new Vector3(movementValue, 0, 0);
        }
        if (position.x <= (minimumSwipeTriggerValue * -1))
        {
            //transform.position += new Vector3(-movementValue, 0, 0);
        }
    }

    public void PauseInputs()
    {
        
    }
}
