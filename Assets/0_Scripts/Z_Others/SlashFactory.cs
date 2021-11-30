using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
