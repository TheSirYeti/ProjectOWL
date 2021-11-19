using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel : MonoBehaviour
{
    private float hp;
    private float maxHp;
    private Transform attackSpawnPoint;
    private GameObject bulletPrefab;
    
    public Action<float, float> OnDamageRecieved;
    public Action OnDeath;
    
    public TankModel(float hp, float maxHp, Transform attackSpawnPoint, GameObject bulletPrefab)
    {
        this.hp = hp;
        this.maxHp = maxHp;
        this.attackSpawnPoint = attackSpawnPoint;
        this.bulletPrefab = bulletPrefab;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnDeath?.Invoke();
        }
        else OnDamageRecieved?.Invoke(hp, maxHp);
    }

    public void Attack(Transform target)
    {
        Vector3 dir = target.transform.position - attackSpawnPoint.transform.position;
        dir.y += 1f;

        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = attackSpawnPoint.position;
        bullet.transform.forward = dir;
    }
}
