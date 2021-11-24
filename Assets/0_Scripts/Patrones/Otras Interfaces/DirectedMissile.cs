using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedMissile : MovingObjects
{
    public Transform target;
    public override IEnumerator StartMovement()
    {
        transform.forward = target.position;
        while (true)
        {
            yield return new WaitForSeconds(timeToUpdate);
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }
    }
}
