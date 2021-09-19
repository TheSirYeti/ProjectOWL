using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwipeMovement : MonoBehaviour
{
    public float movementValue;
    public float minimumSwipeTriggerValue;
    private void Start()
    {
        SwipeManager.instance.OnEndTouch += EndTouch;
    }

    void EndTouch(Vector2 position)
    {
        if (position.x >= minimumSwipeTriggerValue)
        {
            transform.position += new Vector3(movementValue, 0, 0);
        }
        if (position.x <= (minimumSwipeTriggerValue * -1))
        {
            transform.position += new Vector3(-movementValue, 0, 0);
        }
    }
}
