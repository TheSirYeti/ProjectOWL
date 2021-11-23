using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TankBoss : MonoBehaviour
{
        
    [SerializeField] float hp;
    [SerializeField] float maxHp;
    [SerializeField] Transform attackSpawnPoint;
    [SerializeField] Transform target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float attackRate;

    private TankModel model;
    private TankController controller;
    private TankView view;
    void Start()
    {
        model = new TankModel(hp, maxHp, attackSpawnPoint, target, bulletPrefab, attackRate);
        controller = new TankController(model);

        StartCoroutine(GenerateAttack());
    }

    IEnumerator GenerateAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRate);
            controller.Attack();
        }
    }
}
