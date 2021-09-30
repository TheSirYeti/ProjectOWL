using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] 
    private Transform[] spawnPoints;
    ObjectPooler objectPooler;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    
   
    void Start()
    {   
        InvokeRepeating("SpawnObstacles", spawnTime, spawnDelay);
    }

    void SpawnObstacles()
    {
        
        Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length)];
        objectPooler = ObjectPooler.Instance;
        int rand = Random.Range (0, ObjectPooler.Instance.pools.Count);
        objectPooler.SpawnFromPool(ObjectPooler.Instance.pools[rand].prefab.tag, _sp.transform.position, _sp.transform.rotation);
    }
}
