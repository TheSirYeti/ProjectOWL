using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class SlashManager : MonoBehaviour
{
    [Header("Pool")]
    private Pool<SlashAttack> _slashPool = null;
    private IFactory<SlashAttack> _slashFactory = null;
    [SerializeField] private string prefabName;
    [SerializeField] private int poolSize;
    
    private void Start()
    {
        _slashFactory = new SlashFactory(prefabName);
        _slashPool = new Pool<SlashAttack>(_slashFactory.Create, SlashAttack.TurnOff, SlashAttack.TurnOn, poolSize);
        
        EventManager.Subscribe("OnSlideSlashTriggered", ThrowSlash);
    }

    public void ThrowSlash(object[] parameters)
    {
        var slash = _slashPool.Get();
        SlashAttack.TurnOn(slash);
        StartCoroutine(slash.StartMovement());
        slash.transform.position = transform.position;
    }
}
