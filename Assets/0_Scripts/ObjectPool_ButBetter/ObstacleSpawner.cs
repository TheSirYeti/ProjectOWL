using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;

    private Pool<Obstacle> _obstaclePool;
    private IFactory<Obstacle> _obstacleFactory;
    public List<string> obstacles;
    
    private Pool<Collectible> _collectiblePool;
    private IFactory<Collectible> _collectibleFactory;
    public List<string> collectibles;
    
    [SerializeField] private float spawnDelay;

    private void Awake()
    {
        _obstacleFactory = new ObstaclesFactory(obstacles);
        _obstaclePool = new Pool<Obstacle>(_obstacleFactory.Create, Obstacle.TurnOff, Obstacle.TurnOn, 20);

        _collectibleFactory = new CollectibleFactory(collectibles);
        _collectiblePool =
            new Pool<Collectible>(_collectibleFactory.Create, Collectible.TurnOff, Collectible.TurnOn, 20);
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
                    Transform _sp = spawnPoints[i];
                    Obstacle.TurnOn(obstacle);
                    obstacle.transform.position = _sp.transform.position;
                    obstacle.transform.rotation = _sp.transform.rotation;
                }
                else
                {
                    int rand = UnityEngine.Random.Range(0, 3);
                    if (rand == 1)
                    {
                        var collectible = _collectiblePool.Get();
                        Transform _sp = spawnPoints[i];
                        Collectible.TurnOn(collectible);
                        collectible.transform.position = _sp.transform.position;
                    }
                }
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
