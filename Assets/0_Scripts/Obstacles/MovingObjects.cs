using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MovingObjects : MonoBehaviour, IPooledObject
{
    [SerializeField] private float timeToUpdate;
    [SerializeField] private float speed;
    [SerializeField] private float timeToDespawn;


    private bool movingCondition = true;

    public void OnObjectSpawn()
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            EventManager.Trigger("SetHP", -1f);
        }
    }
}