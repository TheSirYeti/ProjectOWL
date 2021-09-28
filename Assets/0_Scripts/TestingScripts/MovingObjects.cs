using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour, IPooledObject
{
   
    public void OnObjectSpawn()
    {
        transform.position += transform.forward * Time.deltaTime;
    }

}