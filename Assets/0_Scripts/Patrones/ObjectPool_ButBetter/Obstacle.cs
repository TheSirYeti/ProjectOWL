using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN CRUZ CRISTÓFALO
public class Obstacle : MovingObjects
{
    private float damage;
    public bool isHeavy;
    public void Start()
    {
        GenerateMovement();
        if (isHeavy)
        {
            speed = ObstacleFlyweightPointer.heavyObstacle.speed;
            damage = ObstacleFlyweightPointer.heavyObstacle.damage;
            timeToUpdate = ObstacleFlyweightPointer.heavyObstacle.timeToUpdate;
            timeToDespawn = ObstacleFlyweightPointer.heavyObstacle.timeToDespawn;
        }
        else
        {
            speed = ObstacleFlyweightPointer.normalObstacle.speed;
            damage = ObstacleFlyweightPointer.normalObstacle.damage;
            timeToUpdate = ObstacleFlyweightPointer.normalObstacle.timeToUpdate;
            timeToDespawn = ObstacleFlyweightPointer.normalObstacle.timeToDespawn;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            movingCondition = false;
            Obstacle.TurnOff(this);
            EventManager.Trigger("OnObstacleCollision", -damage);
        }
    }
    
    public override IEnumerator StartMovement()
    {
        movingCondition = true;
        StartCoroutine(ObjectMovement());
        yield return new WaitForSeconds(timeToDespawn);
        movingCondition = false;
        Obstacle.TurnOff(this);
    }
    
    
    //For ObjectPool
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
