using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnTargets : MonoBehaviour
{
    public static SpawnTargets instance;

    public List<GameObject> currentTargets;

    public List<Transform> allPosiitons;
    private List<bool> occupiedStatus;
    
    public List<GameObject> goodPrefabs, badPrefabs;

    public float reactionTime, waitTime;
    public int targetAmount, targetSize;

    private bool hasHit = false;
    private void Start()
    {
        ResetOccupiedStatus();
        ResetTargets();
        StartCoroutine(DoTargetCountdown());
        
        EventManager.Subscribe("OnGoodTargetHit", OnGoodTargetHit);
        EventManager.Subscribe("OnBadTargetHit", OnBadTargetHit);
    }

    public void OnBadTargetHit(object[] parameters)
    {
        ResetTargets();
        SoundManager.instance.PlaySound(SoundID.MINIGAME_L);
        EventManager.Trigger("OnMiniGameEnd");
        EventManager.Trigger("OnTargetPressed");
    }

    public void OnGoodTargetHit(object[] parameters)
    {
        hasHit = true;
        ResetOccupiedStatus();
        ResetTargets();
        StartCoroutine(DoTargetCountdown());
        EventManager.Trigger("OnTargetPressed");
    }

    public void GenerateTargets()
    {
        currentTargets = new List<GameObject>();

        int rand = Random.Range(0, targetAmount);
        for (int i = 0; i < targetAmount; i++)
        {
            GameObject target;
            if (i == rand)
            {
                target = Instantiate(goodPrefabs[Random.Range(0, goodPrefabs.Count)]);
            }
            else
            {
                target = Instantiate(badPrefabs[Random.Range(0, badPrefabs.Count)]);
            }

            target.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            int randPos = Random.Range(0, allPosiitons.Count);
            while (occupiedStatus[randPos])
            {
                randPos = Random.Range(0, allPosiitons.Count);
            }
            occupiedStatus[randPos] = true;
            target.transform.position = allPosiitons[randPos].position;
            currentTargets.Add(target);
        }
        StartCoroutine(CheckForHits());
        foreach (GameObject target in currentTargets)
        {
            target.SetActive(true);
        }

        if (targetAmount <= 5)
        {
            targetAmount++;
        }
    }

    void ResetOccupiedStatus()
    {
        occupiedStatus = new List<bool>();
        for (int i = 0; i < allPosiitons.Count; i++)
        {
            bool status = false;
            occupiedStatus.Add(status);
        }
    }

    IEnumerator DoTargetCountdown()
    {
        yield return new WaitForSeconds(waitTime);
        GenerateTargets();
    }

    IEnumerator CheckForHits()
    {
        EventManager.Trigger("OnStartScan", reactionTime);
        hasHit = false;
        yield return new WaitForSeconds(reactionTime);
        if (hasHit == false)
        {
            OnBadTargetHit(null);
        }
    }

    void ResetTargets()
    {
        StopCoroutine(DoTargetCountdown());
        StopCoroutine(CheckForHits());
        foreach (GameObject target in currentTargets)
        {
            Destroy(target);
        }

        currentTargets = new List<GameObject>();

        if (waitTime > 0.5f)
        {
            waitTime -= 0.1f;
        }

        if (reactionTime > 0.1f)
        {
            reactionTime -= 0.1f;
        }
    }
}