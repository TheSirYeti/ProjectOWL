using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private Pool<Obstacle> _pool;
    private IFactory<Obstacle> _factory;

    private void Awake()
    {
        _factory = new ObstaclesFactory();
        _pool = new Pool<Obstacle>(_factory.Create, Obstacle.TurnOff, Obstacle.TurnOn, 5);
    }
}
