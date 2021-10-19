using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawner : MonoBehaviour
{
    [Header("Spawnpoints")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnDelay;
    
    [Header("Obstacle Items")]
    public List<string> obstacles;
    
    private Pool<Obstacle> _obstaclePool;
    private IFactory<Obstacle> _obstacleFactory;

    [Header("Collectible Items")]
    public List<string> collectibles;
    
    private Pool<Collectible> _collectiblePool;
    private IFactory<Collectible> _collectibleFactory;

    private void Awake()
    {
        _obstacleFactory = new ObstaclesFactory(obstacles);
        _obstaclePool = new Pool<Obstacle>(_obstacleFactory.Create, Obstacle.TurnOff, Obstacle.TurnOn, 40);

        _collectibleFactory = new CollectibleFactory(collectibles);
        _collectiblePool =
            new Pool<Collectible>(_collectibleFactory.Create, Collectible.TurnOff, Collectible.TurnOn, 40);
    }
    
    public void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            int freeSpace = UnityEngine.Random.Range(0, spawnPoints.Length);
            Debug.Log(freeSpace);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i != freeSpace)
                {
                    var obstacle = _obstaclePool.Get();
                    Transform spawnPoint = spawnPoints[i];
                    Obstacle.TurnOn(obstacle);
                    obstacle.transform.position = spawnPoint.transform.position;
                    obstacle.transform.rotation = spawnPoint.transform.rotation;
                }
                else
                {
                    int rand = UnityEngine.Random.Range(0, 3); //33% de chance de que spawnee un Collectible
                    if (rand == 1)
                    {
                        var collectible = _collectiblePool.Get();
                        Transform spawnPoint = spawnPoints[i];
                        Collectible.TurnOn(collectible);
                        collectible.transform.position = spawnPoint.transform.position;
                        collectible.transform.rotation = spawnPoint.transform.rotation;
                    }
                }
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
