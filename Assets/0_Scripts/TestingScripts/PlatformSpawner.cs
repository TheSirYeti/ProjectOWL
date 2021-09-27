using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

   /* ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    } */
    
    // Update is called once per frame
    void FixedUpdate()
    {
        ObjectPooler.Instance.SpawnFromPool("Cube", transform.position, Quaternion.identity);
        ObjectPooler.Instance.SpawnFromPool("Rectangle", transform.position, Quaternion.identity);
    }
}
