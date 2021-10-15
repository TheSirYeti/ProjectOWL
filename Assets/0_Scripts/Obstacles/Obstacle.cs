using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObjects //, MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            EventManager.Trigger("OnObstacleCollision", -1f);
            movingCondition = false;
            gameObject.SetActive(false);
        }
    }

    public static Obstacle TurnOff(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
        return obstacle;
    }

    public static Obstacle TurnOn(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(true);
        return obstacle;
    }

}
