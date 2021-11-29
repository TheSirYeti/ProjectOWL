using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN CRUZ CRISTÓFALO
public class ObstaclesFactory : IFactory<Obstacle>
{
    List<string> obstacles;
    
    public ObstaclesFactory (List<string> strings)
    {
        obstacles = strings;
    }
    
    public Obstacle Create()
    {
        //var prefab = Resources.Load<Obstacle>(ChooseRandomObstacle());
        var prefab = ResourceTable.instance.GetObstaclePrefab(ChooseRandomObstacle());
        return GameObject.Instantiate(prefab);
    }

    public string ChooseRandomObstacle()
    {
        int rand = UnityEngine.Random.Range(0, obstacles.Count);
        return obstacles[rand];
    }
}
