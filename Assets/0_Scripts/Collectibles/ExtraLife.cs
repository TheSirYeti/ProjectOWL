using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour, ICollectible, IMovable
{
    public float speed;
    public float value;
    public void OnCollect()
    {
        EventManager.Trigger("UpdateScore", value);
        EventManager.Trigger("SetHP", 1f);
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
