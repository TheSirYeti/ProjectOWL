using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesFactory : IFactory<Obstacle>
{
    public Obstacle Create()
    {
        var prefab = Resources.Load<Obstacle>("obstacle");
        return GameObject.Instantiate(prefab);
    }

    
}
