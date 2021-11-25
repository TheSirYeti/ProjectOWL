using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : Collectible
{
    private Transform target;
    [SerializeField] float timeToDespawn = 2f;
    [SerializeField] float timeToUpdate = 0.0001f;
    public override void OnCollect()
    {
        Debug.Log("LO HACES???");
        GetTarget();
        EventManager.Trigger("OnFootballCollected", "Kick");
        StartCoroutine(GoToTarget());
        Debug.Log("LO HICE");
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
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
            timeToDespawn -= timeToUpdate;
            Debug.Log("hola2222");
            if (timeToDespawn <= 0f)
            {
                flag = false;
            }
        }

        TurnOff(this);
    }
}
