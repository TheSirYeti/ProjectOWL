using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleFactory : IFactory<Collectible>
{
    public List<string> collectibles;
    
    public CollectibleFactory(List<string> strings)
    {
        collectibles = strings;
    }
    
    public Collectible Create()
    {
        var prefab = Resources.Load<Collectible>(RandomCollectible());
        return GameObject.Instantiate(prefab);
    }

    public string RandomCollectible()
    {
        int rand = UnityEngine.Random.Range(0, collectibles.Count);
        return collectibles[rand];
    }
}