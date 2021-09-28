using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour, IPooledObject
{
  
    public float  forceMult = 200;
    private Rigidbody rb;
    
    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Time.deltaTime * forceMult; 
        Destroy(gameObject, 5f);
    }
}