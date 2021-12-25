using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID

public class TankController : MonoBehaviour
{
    //Model del MVC
    [SerializeField] private TankModel model;

    //Metodos para el View
    public Action<float, float> OnDamageRecieved;
    public Action OnAttackShot;
    public Action OnDeath;
    
    //ObjectPool del Misil
    private Pool<DirectedMissile> _missilePool = null;
    private IFactory<DirectedMissile> _missileFactory = null;
    [SerializeField] private int _poolSize = 15;
    [SerializeField] private string _missilePrefabName;
    
    bool _attackRateFlag = false;
    
    public TankController(TankModel model)
    {
        this.model = model;
    }

    private void Start()
    {
        EventManager.Subscribe("OnFootballKicked", CollisionReaction);
        _missileFactory = new MissileFactory(_missilePrefabName);
        _missilePool = new Pool<DirectedMissile>(_missileFactory.Create, DirectedMissile.TurnOff, DirectedMissile.TurnOn, _poolSize);
    }

    private void Update()
    {
        Attack();
    }

    //Generamos un ataque
    public void Attack()
    {
        if (model.hp > 0 && model.attackCooldown <= Time.fixedTime)
        {
            Vector3 dir = model.target.transform.position - model.attackSpawnPoint.transform.position;
            dir.y += 1f;

            var bullet = _missilePool.Get();
            bullet.transform.position = model.attackSpawnPoint.position;
            bullet.transform.forward = dir;
            DirectedMissile.TurnOn(bullet);
            OnAttackShot?.Invoke();

            model.attackCooldown = Time.fixedTime + model.attackRate;
        }
    }
    
    public void TakeDamage(float damage)
    {
        model.hp -= damage;
        if (model.hp <= model.maxHp / 2 && !_attackRateFlag)
        {
            _attackRateFlag = true;
            model.attackRate /= 2;
        }
        if (model.hp <= 0)
        {
            OnDeath?.Invoke();
            model.hp = 0;
            PlayerPrefs.SetInt("BeatBoss", 1);
        }
        else OnDamageRecieved?.Invoke(model.hp, model.maxHp);
    }
    
    //Si se triggerea el evento, significa que el Boss tomo daño
    void CollisionReaction(object[] parameters)
    {
        TakeDamage((float)parameters[0]);
    }
}
