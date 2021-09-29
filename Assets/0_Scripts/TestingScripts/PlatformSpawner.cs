using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] 
    private Vector3[] spawnPoints;
    ObjectPooler objectPooler;

    private void Start()
    {
        /*objectPooler = ObjectPooler.Instance;
        objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool("Rectangle", transform.position, Quaternion.identity);*/
    } 
    
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 vector = SpawnPoints();

            objectPooler = ObjectPooler.Instance;
            objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);        

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 vector = SpawnPoints();

            objectPooler = ObjectPooler.Instance;
            objectPooler.SpawnFromPool("Rectangle", transform.position, Quaternion.identity);        

        }
    }

    Vector3 SpawnPoints()
    {
        float x = -3.27f;
        float y = -1.208225f;
        float z = 0.756813f;

        Vector3 vector = new Vector3(x, y, z);

        return vector;
    }
}
