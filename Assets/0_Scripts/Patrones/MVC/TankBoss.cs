using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class TankBoss : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] float hp;
    [SerializeField] float maxHp;
    [SerializeField] Transform attackSpawnPoint;
    [SerializeField] Transform target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float attackRate;

    [Header("View")]
    [SerializeField] private ParticleSystem shootingSmoke;
    [SerializeField] private ParticleSystem dyingEffect;
    [SerializeField] private Slider hpBar;
    [SerializeField] private Animator animator;

    
    
    private TankModel model;
    private TankController controller;
    [SerializeField] TankView view;
    void Start()
    {
        model = new TankModel(hp, maxHp, attackSpawnPoint, target, bulletPrefab, attackRate);
        controller = new TankController(model);
        view = new TankView(shootingSmoke, dyingEffect, hpBar, model, animator);
        
        
        EventManager.Subscribe("OnFootballKicked", OnAttackCollision);
    }

    private void Update()
    {
        controller.Attack();
    }

    void OnAttackCollision(object[] parameters)
    {
        model.TakeDamage((float)parameters[0]);
    }
}
