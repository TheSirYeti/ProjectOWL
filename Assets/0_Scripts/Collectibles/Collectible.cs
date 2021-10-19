using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public abstract class Collectible : MonoBehaviour, IMovable, ICollectible
{ 
    [SerializeField] private float _speed;
    private ICollectible _collectible;

    public Collectible(){}
    
    public Collectible(float speed)
    {
        _speed = speed;
    }
    
    public Collectible(float speed, Token coin)
    {
        _speed = speed;
        _collectible = coin;
    }
    
    public Collectible(float speed, ExtraLife extraLife)
    {
        _speed = speed;
        _collectible = extraLife;
    }
    
    public Collectible(float speed, HighJump highJump)
    {
        _speed = speed;
        _collectible = highJump;
    }

    public Collectible(float speed, Shield shield)
    {
        _speed = speed;
        _collectible = shield;
    }
    
    
    /*private void Start()
    {
        _collectible = this;
    }*/

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
        transform.position -= transform.forward * Time.deltaTime * _speed;
    }

    public abstract void OnCollect();
}
