using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private TankModel model;
    private TankView view;
    
    [SerializeField] float hp;
    [SerializeField] float maxHp;
    [SerializeField] Transform attackSpawnPoint;
    [SerializeField] Transform target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float attackRate;
    
    public TankController(TankModel model, TankView view)
    {
        this.model = model;
        this.view = view;
    }

    private void Start()
    {
        model = new TankModel(hp, maxHp, attackSpawnPoint, bulletPrefab);
        StartCoroutine(GenerateAttack());
    }

    IEnumerator GenerateAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRate);
            model.Attack(target);
            Debug.Log("ataque");
        }
    }
}
