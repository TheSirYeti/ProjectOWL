using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID

public class TankView : MonoBehaviour
{
    //Particulas
    [SerializeField] ParticleSystem shootingSmoke, dyingEffect;
    //Animaciones
    [SerializeField] Animator animator;
    //Barra de Vida
    [SerializeField] Slider hpBar; 
    //Aunque es ambiguo si poner algo de la UI repseta de S de SOLID, me parecio mas optimo que
    //armar un script nuevo para organizarle la vida al Boss.
    
    //Referencia del Controller para subscribirse a los metodos.
    [SerializeField] TankController controller;

    private void Start()
    {
        controller.OnDamageRecieved += ShowHP;
        controller.OnDeath += TankDeath;
        controller.OnAttackShot += AttackFX;
    }

    //Actualizamos la barra de HP
    public void ShowHP(float currentHP, float maxHP)
    {
        hpBar.value = currentHP / maxHP;
    }

    //Muestra la animacion y efectos de muerte
    public void TankDeath()
    {
        hpBar.value = 0f;
        dyingEffect.Play();
        animator.Play("Death");
    }

    //Mostramos las particulas de ataque
    public void AttackFX()
    {
        SoundManager.instance.PlaySound(SoundID.SHOT);
        shootingSmoke.Play();
    }
    
    
    //via AnimationEvent
    public void Kill()
    {
        EventManager.Trigger("OnBossDestroyed", "You Won!");
    }
}
