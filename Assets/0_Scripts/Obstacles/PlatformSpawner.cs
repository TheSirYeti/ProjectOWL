using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] 
    private Transform[] spawnPoints;
    ObjectPooler objectPooler;
    
    //hay que hacer que el object pool no sea mas estatico, pero por el momento lo dejo asi
    public List<GameObject> powerUpList = new List<GameObject>();

    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;


    void Start()
    {   
        //InvokeRepeating("SpawnObstacles", spawnTime, spawnDelay);
        StartCoroutine(SpawnObjects());
    }

    void SpawnObstacles()
    {
        Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length)];
        objectPooler = ObjectPooler.Instance;
        int rand = Random.Range (0, ObjectPooler.Instance.pools.Count);
        objectPooler.SpawnFromPool(ObjectPooler.Instance.pools[rand].prefab.tag, _sp.transform.position, _sp.transform.rotation);
    }

    IEnumerator SpawnObjects()
    {
        objectPooler = ObjectPooler.Instance;
        while (true)
        {
            int freeSpace = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i != freeSpace)
                {
                    Transform _sp = spawnPoints[i];
                    int rand = Random.Range (0, ObjectPooler.Instance.pools.Count);
                    objectPooler.SpawnFromPool(ObjectPooler.Instance.pools[rand].prefab.tag, _sp.transform.position, _sp.transform.rotation);
                }
                else
                {
                    //FIXEAR PARA MODELOS
                    int rand = Random.Range(0, 2);
                    if (rand == 1)
                    {
                        Transform _sp = spawnPoints[i];
                        int powerUpValue = Random.Range(0, powerUpList.Count);
                        GameObject powerUp = Instantiate(powerUpList[powerUpValue]);
                        powerUp.transform.position = _sp.transform.position;
                    }
                }
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
