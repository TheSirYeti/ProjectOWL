using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public SkinnedMeshRenderer renderer;

    public List<Material> allSkins;

    private void Start()
    {
        renderer.material = allSkins[SkinManager.instance.currentSkin];
    }
}
