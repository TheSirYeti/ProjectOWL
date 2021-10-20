using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ResourceTable : MonoBehaviour
{
    public LookUpTable<string, Obstacle> obstacleTable;
    public LookUpTable<string, Collectible> collectibleTable;
    
    public static ResourceTable instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("There already was an instance of " + this + ". Destroying...");
            Destroy(gameObject);
        }
        obstacleTable = new LookUpTable<string, Obstacle>(GenerateObstacle);
        collectibleTable = new LookUpTable<string, Collectible>(GenerateCollectible);
    }

    public Obstacle GetObstaclePrefab(string name)
    {
        return obstacleTable.Get(name);
    }
    
    public Collectible GetCollectiblePrefab(string name)
    {
        return collectibleTable.Get(name);
    }
    
    public Obstacle GenerateObstacle(string name)
    {
        return Resources.Load<Obstacle>(name);
    }
    
    public Collectible GenerateCollectible(string name)
    {
        return Resources.Load<Collectible>(name);
    }
}
