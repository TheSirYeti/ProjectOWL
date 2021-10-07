using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObjects : MonoBehaviour, IPooledObject, IMovable
{
    [SerializeField] private float timeToUpdate;
    [SerializeField] private float speed;
    [SerializeField] private float timeToDespawn;


    public bool movingCondition = true;
    
    public void OnObjectSpawn()
    {
        StartMoving();
    }

    public void StartMoving()
    {
        StartCoroutine(StartMovement());
    }
    
    IEnumerator ObjectMovement()
    {
        while (movingCondition)
        {
            yield return new WaitForSeconds(timeToUpdate);
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
    }

    IEnumerator StartMovement()
    {
        movingCondition = true;
        StartCoroutine(ObjectMovement());
        yield return new WaitForSeconds(timeToDespawn);
        movingCondition = false;
        gameObject.SetActive(false);
    }
}