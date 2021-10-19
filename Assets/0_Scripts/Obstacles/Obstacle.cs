using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObjects //, MonoBehaviour
{
    public void Start()
    {
        GenerateMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            movingCondition = false;
            Obstacle.TurnOff(this);
            EventManager.Trigger("OnObstacleCollision", -1f);
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
    public override IEnumerator StartMovement()
    {
        movingCondition = true;
        StartCoroutine(ObjectMovement());
        yield return new WaitForSeconds(timeToDespawn);
        movingCondition = false;
        Obstacle.TurnOff(this);
    }
}
