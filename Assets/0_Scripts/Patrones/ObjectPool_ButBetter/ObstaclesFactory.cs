using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesFactory : IFactory<Obstacle>
{
    public List<string> obstacles;
    
    public ObstaclesFactory (List<string> strings)
    {
        obstacles = strings;
    }
    
    public Obstacle Create()
    {
        var prefab = Resources.Load<Obstacle>(ChooseRandomObstacle());
        return GameObject.Instantiate(prefab);
    }

    public string ChooseRandomObstacle()
    {
        int rand = UnityEngine.Random.Range(0, obstacles.Count);
        return obstacles[rand];
    }
}
