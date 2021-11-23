using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private TankModel model;
    private TankView view;
    

    public TankController(TankModel model)
    {
        this.model = model;
    }

    public void Attack()
    {
        model.Attack();
    }
}
