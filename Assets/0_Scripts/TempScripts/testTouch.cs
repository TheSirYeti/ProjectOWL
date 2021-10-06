using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTouch : MonoBehaviour
{
    private void Start()
    {
        SwipeManager.instance.OnStartTouch += DoStart;
        SwipeManager.instance.OnUpdateTouch += DoUpdate;
        SwipeManager.instance.OnEndTouch += DoEnd;
    }

    public void DoStart(Vector2 position)
    {
        transform.position = new Vector3(0, 5, 0);
    }
    
    public void DoUpdate(Vector2 position)
    {
        transform.position = new Vector3(0, 0, 0);
    }
    
    public void DoEnd(Vector2 position)
    {
        transform.position = new Vector3(0, -5, 0);
    }
}
