using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID

public class ObstacleFlyweightPointer : MonoBehaviour
{
    public static readonly ObstacleFlyweight timers = new ObstacleFlyweight()
    {
        timeToUpdate = 0.000001f,
        timeToDespawn = 20f
    };
    
    public static readonly ObstacleFlyweight normalObstacle = new ObstacleFlyweight
    {
        speed = 60f,
        damage = 1f,
    };
    
    public static readonly ObstacleFlyweight heavyObstacle = new ObstacleFlyweight
    {
        speed = 60f,
        damage = 2f,
    };
    
    public static readonly ObstacleFlyweight slowObstacle = new ObstacleFlyweight
    {
        speed = 40f,
        damage = 1f,
    };
}
