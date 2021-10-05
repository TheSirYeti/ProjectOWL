using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour, ICollectible, IMovable
{
    public float value;
    public float speed;
    public void OnCollect()
    {
        EventManager.Trigger("UpdateScore", value);
    }

    private void FixedUpdate()
    {
        StartMoving();
    }

    public void StartMoving()
    {
        transform.position -= transform.forward * Time.deltaTime * speed;
    }
}
