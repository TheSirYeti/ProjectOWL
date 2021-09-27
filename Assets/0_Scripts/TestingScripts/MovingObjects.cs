using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour, IPooledObject
{
  
    public float  speed;
    
    public void OnObjectSpawn()
    {
        transform.position -= transform.forward * speed * Time.deltaTime; 
        Destroy(gameObject, 5f);
    }
}