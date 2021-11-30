using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour, ISubscriber
{
    private IAbility ability;
    private IAbility nextAbility;

    [SerializeField] private Observer _playerObserver = null;

    [SerializeField] private float timeRemaining;

    private void Start()
    {
        EventManager.Subscribe("OnAbilityCollected", LoadAbility);
        EventManager.Subscribe("OnAbilityEnd", EndAbility);
        _playerObserver.Subscribe(this);
        ability = new NormalSlide();
    }

    void LoadAbility(object[] parameters)
    {
        Debug.Log("inglessss");
        var upgrade = (IAbility) parameters[0];
        Debug.Log(upgrade);
        if (ability != upgrade)
        {
            var aux = ability;
            ability = upgrade;
            ability.SetNext(aux);
        }
    }

    void EndAbility(object[] parameters)
    {
        ability = new NormalSlide();
    }

    public void OnNotify(string eventID)
    {
        if (eventID == "Slide")
        {
            Debug.Log("hago slide");
            ability.OnSlideDown();
        }
    }
}
