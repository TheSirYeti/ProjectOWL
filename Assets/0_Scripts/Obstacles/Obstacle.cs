using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObjects
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            EventManager.Trigger("SetHP", -1f);
            movingCondition = false;
            gameObject.SetActive(false);
        }
    }
}
