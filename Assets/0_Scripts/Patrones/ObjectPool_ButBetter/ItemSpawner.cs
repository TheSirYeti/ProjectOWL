using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN CRUZ CRISTÓFALO
public class ItemSpawner : MonoBehaviour
{
    [Header("Spawnpoints")]
    [SerializeField] private Transform[] spawnPoints = null;
    [SerializeField] private float spawnDelay = 0f;
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float spawnDelayRate;
    
    [Header("Obstacle Items")]
    public List<string> obstacles;

    public int poolSize;
    
    private Pool<Obstacle> _obstaclePool = null;
    private IFactory<Obstacle> _obstacleFactory = null;

    [Header("Collectible Items")]
    public List<string> collectibles;
    
    private Pool<Collectible> _collectiblePool = null;
    private IFactory<Collectible> _collectibleFactory = null;

    private void Start()
    {
        _obstacleFactory = new ObstaclesFactory(obstacles);
        _obstaclePool = new Pool<Obstacle>(_obstacleFactory.Create, Obstacle.TurnOff, Obstacle.TurnOn, poolSize);

        _collectibleFactory = new CollectibleFactory(collectibles);
        _collectiblePool = new Pool<Collectible>(_collectibleFactory.Create, Collectible.TurnOff, Collectible.TurnOn, poolSize);
        
        EventManager.Subscribe("OnDistanceCheck", ChangeRate);
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            int freeSpace = UnityEngine.Random.Range(0, spawnPoints.Length);
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

    public void ChangeRate(object[] parameters)
    {
        if (spawnDelay >= minSpawnDelay)
        {
            spawnDelay -= spawnDelayRate;
        }
    }
}
