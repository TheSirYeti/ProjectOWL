using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;

    private Pool<Obstacle> _pool;
    private IFactory<Obstacle> _factory;
    public List<string> obstacles;

    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    
    private void Awake()
    {
        _factory = new ObstaclesFactory(obstacles);
        _pool = new Pool<Obstacle>(_factory.Create, Obstacle.TurnOff, Obstacle.TurnOn, 20);
    }
    public void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    /*public virtual void SpawnObst()
    {
        Transform _sp = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        var obstacle = _pool.Get();
    }*/

    IEnumerator SpawnObjects()
    {
        
        while (true)
        {
            var obstacle = _pool.Get();
            int freeSpace = UnityEngine.Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i != freeSpace)
                {
                    Transform _sp = spawnPoints[i];
                    int rand = UnityEngine.Random.Range(0, 20);
                    Obstacle.TurnOn(obstacle);
                    obstacle.transform.position = _sp.transform.position;
                    obstacle.transform.rotation = _sp.transform.rotation;
                }
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
