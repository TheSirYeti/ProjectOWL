using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class LoopingFloor : MonoBehaviour
{
    public List<Transform> roads = new List<Transform>();
    public Transform startPos, endPos;
    public float speed;
    private bool isGameActive = true;


    private void Start()
    {
        EventManager.Subscribe("OnPlayerDeath", DisableLoopingRoads);
    }

    private void Update()
    {
        if (Time.timeScale == 1f && isGameActive)
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

    public void DisableLoopingRoads(object[] parameters)
    {
        isGameActive = false;
    }
}
