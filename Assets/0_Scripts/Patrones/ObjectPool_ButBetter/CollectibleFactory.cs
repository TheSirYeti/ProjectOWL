using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID, JUAN CRUZ CRISTÓFALO
public class CollectibleFactory : IFactory<Collectible>
{
    public List<string> collectibles;
    
    public CollectibleFactory(List<string> strings)
    {
        collectibles = strings;
    }
    
    public Collectible Create()
    {
        //var prefab = Resources.Load<Collectible>(ChooseRandomCollectible());
        var prefab = ResourceTable.instance.GetCollectiblePrefab(ChooseRandomCollectible());
        return GameObject.Instantiate(prefab);
    }

    public string ChooseRandomCollectible()
    {
        int rand = UnityEngine.Random.Range(0, collectibles.Count);
        return collectibles[rand];
    }
}