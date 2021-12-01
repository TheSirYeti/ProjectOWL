using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class SlashFactory : IFactory<SlashAttack>
{
    [SerializeField] private string prefabName;

    public SlashFactory(string prefabName)
    {
        this.prefabName = prefabName;
    }

    public SlashAttack Create()
    {
        var prefab = Resources.Load<SlashAttack>(prefabName);
        return GameObject.Instantiate(prefab);
    }
}
