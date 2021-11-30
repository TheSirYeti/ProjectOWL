using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    //Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, detectableAgentMask);
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ParticleSystem explosionVFX;

    private void Start()
    {
        EventManager.Subscribe("OnSlideExplosionTriggered", Explode);
    }

    void Explode(object[] parameters)
    {
        explosionVFX.Play();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, explosionRadius, _layerMask);

        foreach (var item in targetsInViewRadius)
        {
            Debug.Log("hola1414");
            item.gameObject.SetActive(false);
        }
    }
}
