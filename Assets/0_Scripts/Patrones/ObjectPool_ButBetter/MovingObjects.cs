using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN CRUZ CRISTÓFALO
public abstract class MovingObjects : MonoBehaviour, IMovable
{
    public float timeToUpdate = 0f;
    public float speed = 0f;
    public float timeToDespawn = 0f;
    public float sinModifier;
    public float period;
    
    public bool isSinMovement;
    
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

            if (isSinMovement)
            {
                transform.position -= (transform.forward + new Vector3(Mathf.Sin(Time.fixedTime * period) * sinModifier, 0f, 0f)) * Time.deltaTime * speed;
            } 
            else transform.position -= transform.forward * Time.deltaTime * speed;
        }
    }

    public abstract IEnumerator StartMovement();
    
}