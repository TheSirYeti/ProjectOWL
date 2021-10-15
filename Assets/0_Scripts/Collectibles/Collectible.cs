using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public abstract class Collectible : MonoBehaviour, IMovable, ICollectible
{ 
    [SerializeField] private float speed;
    private ICollectible _collectible;

    private void Start()
    {
        _collectible = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            _collectible.OnCollect();
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

    public abstract void OnCollect();
}
