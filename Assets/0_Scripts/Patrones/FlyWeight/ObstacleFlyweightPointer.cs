using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFlyweightPointer : MonoBehaviour
{
    public static readonly ObstacleFlyweight normalObstacle = new ObstacleFlyweight
    {
        speed = 60f,
        damage = 1f,
        timeToUpdate = 0.000001f,
        timeToDespawn = 20f
    };
    
    public static readonly ObstacleFlyweight heavyObstacle = new ObstacleFlyweight
    {
        speed = 60f,
        damage = 2f,
        timeToUpdate = 0.000001f,
        timeToDespawn = 20f
    };
}
