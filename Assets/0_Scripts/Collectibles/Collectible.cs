using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public abstract class Collectible : MonoBehaviour, IMovable, ICollectible
{
    [Header("Values")]
    public int value;
    public int speed;
    public ICollectible collectibleType;

    private void Start()
    {
        collectibleType = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectibleType.OnCollect();
            TurnOff(this);
        }
    }

    private void FixedUpdate()
    {
        GenerateMovement();
    }

    public void GenerateMovement()
    {
        transform.position -= transform.forward * Time.deltaTime * speed;
    }

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
    
    public abstract void OnCollect();
}
