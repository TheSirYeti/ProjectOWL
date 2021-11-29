using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFactory : IFactory<DirectedMissile>
{
    private string prefabName;

    public MissileFactory(string prefabName)
    {
        this.prefabName = prefabName;
    }

    public DirectedMissile Create()
    {
        var prefab = Resources.Load<DirectedMissile>(prefabName);
        return GameObject.Instantiate(prefab);
    }
}
