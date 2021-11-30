using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlashAttack : MovingObjects
{
    //For ObjectPool
    public static SlashAttack TurnOff(SlashAttack slash)
    {
        slash.gameObject.SetActive(false);
        return slash;
    }

    public static SlashAttack TurnOn(SlashAttack slash)
    {
        slash.gameObject.SetActive(true);
        return slash;
    }

    public override IEnumerator StartMovement()
    {
        bool flag = true;
        float despawnPoint = Time.fixedDeltaTime + timeToDespawn;
        float counter = Time.fixedDeltaTime;
        while (flag)
        {
            yield return new WaitForSeconds(timeToUpdate);
            transform.position += transform.forward * speed * Time.fixedDeltaTime;

            counter += Time.fixedDeltaTime;
            if (counter >= despawnPoint)
            {
                flag = false;
            }
        }
 
        TurnOff(this);
    }
}
