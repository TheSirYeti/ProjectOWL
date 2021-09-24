using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public int currentLane;
    public int amountOfLanes;
    
    public static LaneManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else {Debug.Log("There's already an instance of LaneManager in the scene."); Destroy(gameObject);}
    }

    public void AddLanes(int amount)
    {
        amountOfLanes += amount;
    }   

    public bool IsLaneChangeAllowed(bool direction)
    {
        return default;
    }

    public void SetCurrentLane(int id)
    {
        currentLane = id;
    }
}
