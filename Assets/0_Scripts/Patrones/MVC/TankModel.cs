using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID

public class TankModel : MonoBehaviour
{
    //Variables que usa el Controller del Tanque
    public float hp;
    public float maxHp;
    public Transform attackSpawnPoint;
    public Transform target;
    public float attackRate;
    public float attackCooldown;
}
