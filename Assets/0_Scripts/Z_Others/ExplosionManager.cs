using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class ExplosionManager : MonoBehaviour //Nos encargamos de manejar toda la explosion, incluyendo las particulas.
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ParticleSystem explosionVFX;

    private void Start()
    {
        EventManager.Subscribe("OnSlideExplosionTriggered", Explode);
    }

    void Explode(object[] parameters)
    {
        explosionVFX.Play(); //Aunque rompemos la S de SOLID encargandonos del efecto visual, no me parecia logico crear
                                //un script nuevo entero para hacer que una sola particula se reproduzca.
        
                                
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, explosionRadius, _layerMask);

        foreach (var item in targetsInViewRadius)
        {
            item.gameObject.SetActive(false);
        }
    }
}
