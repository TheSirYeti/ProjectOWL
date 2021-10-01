using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingFloor : MonoBehaviour
{
    public Transform startPos, endPos;
    public float speed;

    private void Update()
    {
        transform.position -= Vector3.forward * speed * Time.fixedDeltaTime;

        if (transform.position.z <= endPos.position.z)
        {
            transform.position = startPos.position;
        }
    }
}
