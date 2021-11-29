using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public Transform attackSpawnPoint;
    public Transform target;
    public float attackRate;
    public float attackCooldown;
}
