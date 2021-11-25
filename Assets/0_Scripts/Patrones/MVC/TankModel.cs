using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel : MonoBehaviour
{
    private float hp;
    private float maxHp;
    private Transform attackSpawnPoint;
    private Transform target;
    private GameObject bulletPrefab;
    private float attackRate;
       
    public Action<float, float> OnDamageRecieved;
    public Action OnAttackShot;
    public Action OnDeath;

    public TankModel(float hp, float maxHp, Transform attackSpawnPoint, Transform target, GameObject bulletPrefab, float attackRate)
    {
        this.hp = hp;
        this.maxHp = maxHp;
        this.attackSpawnPoint = attackSpawnPoint;
        this.target = target;
        this.bulletPrefab = bulletPrefab;
        this.attackRate = attackRate;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnDeath?.Invoke();
            hp = 0;
        }
        else OnDamageRecieved?.Invoke(hp, maxHp);
    }

    public void Attack()
    {
        if (hp > 0)
        {
            Vector3 dir = target.transform.position - attackSpawnPoint.transform.position;
            dir.y += 1f;

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = attackSpawnPoint.position;
            bullet.transform.forward = dir;
            OnAttackShot?.Invoke();
        }
    }
}
