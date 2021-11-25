using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : Collectible
{
    private Transform target;
    [SerializeField] private float attackDamage;
    [SerializeField] float timeToDespawn = 2f;
    [SerializeField] float timeToUpdate = 0.0001f;
    public override void OnCollect()
    {
        GetTarget();
        EventManager.Trigger("OnFootballCollected", "Kick");
        SoundManager.instance.PlaySound(SoundID.KICK);
        StartCoroutine(GoToTarget());
    }

    void GetTarget()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, 15f, 9);

        foreach (var item in targetsInViewRadius)
        {
            target = item.transform;
            Vector3 dir = target.position - transform.position;
        }
    } 
    
    IEnumerator GoToTarget()
    {
        bool flag = true;

        while (flag)
        {
            yield return new WaitForSeconds(timeToUpdate);
            transform.position += transform.forward * (speed * 2) * Time.fixedDeltaTime;
            timeToDespawn -= Time.fixedDeltaTime;
            if (timeToDespawn <= 0f)
            {
                flag = false;
            }
        }
        
        EventManager.Trigger("OnFootballKicked", attackDamage);
        SoundManager.instance.PlaySound(SoundID.HIT);
        TurnOff(this);
    }
}
