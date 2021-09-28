using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool("Rectangle", transform.position, Quaternion.identity);
    } 
    
    // Update is called once per frame
    void FixedUpdate()
    {   

    }
}
