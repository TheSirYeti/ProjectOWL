using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BestTime : MonoBehaviour
{
    public float timer;
    public Text timeUI;
    
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            timer += Time.fixedDeltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string totalTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            timeUI.text = "Time: " + totalTime;
            
        }
    }
}
