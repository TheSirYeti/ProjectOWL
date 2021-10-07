using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingFloor : MonoBehaviour
{
    public List<Transform> roads = new List<Transform>();
    public Transform startPos, endPos;
    public float speed;

    private void Update()
    {
        if (Time.timeScale == 1f)
        {
            foreach (Transform t in roads)
            {
                t.position -= Vector3.forward * speed * Time.fixedDeltaTime;

                if (t.position.z <= endPos.position.z)
                {
                    t.position = startPos.position;
                }
            }
        }
    }
}
