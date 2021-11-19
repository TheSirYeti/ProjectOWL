using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovementTest : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
}
