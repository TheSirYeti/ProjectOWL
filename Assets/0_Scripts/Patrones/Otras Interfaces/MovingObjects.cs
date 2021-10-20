using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID, JUAN CRUZ CRISTÓFALO
public abstract class MovingObjects : MonoBehaviour, IPooledObject, IMovable
{
    [SerializeField] private float timeToUpdate;
    [SerializeField] private float speed;
    [SerializeField] public float timeToDespawn;


    public bool movingCondition = true;
    
    public void OnObjectSpawn()
    {
        GenerateMovement();
    }

    public void GenerateMovement()
    {
        StartCoroutine(StartMovement());
    }
    
    public IEnumerator ObjectMovement()
    {
        while (movingCondition)
        {
            yield return new WaitForSeconds(timeToUpdate);
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
    }

    public abstract IEnumerator StartMovement();
    
}