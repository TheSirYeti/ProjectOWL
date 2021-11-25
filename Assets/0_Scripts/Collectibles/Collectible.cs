using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;


//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public abstract class Collectible : MonoBehaviour, IMovable, ICollectible
{
    [Header("Values")]
    public int value;
    public int speed;
    public ICollectible collectibleType;

    private void Start()
    {
        collectibleType = this;
        Debug.Log(collectibleType);
    }

    private void FixedUpdate()
    {
        GenerateMovement();
    }

    public void GenerateMovement()
    {
        transform.position -= transform.forward * Time.deltaTime * speed;
    }

    public abstract void OnCollect();
    
    
    
    //For ObjectPool
    public static Collectible TurnOff(Collectible collectible)
    {
        collectible.gameObject.SetActive(false);
        return collectible;
    }

    public static Collectible TurnOn(Collectible collectible)
    {
        collectible.gameObject.SetActive(true);
        return collectible;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("COLLISIONE CON PLAYER");
            collectibleType.OnCollect();
        }
    }
}
