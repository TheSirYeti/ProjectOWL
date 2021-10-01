using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : Collectible
{
    public float speed;
    public override void OnCollect()
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
