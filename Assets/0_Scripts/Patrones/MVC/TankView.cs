using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    [SerializeField] ParticleSystem shootingSmoke, dyingEffect;
    [SerializeField] Animator animator;
    [SerializeField] Slider hpBar;

    [SerializeField] TankController controller;

    private void Start()
    {
        controller.OnDamageRecieved += ShowHP;
        controller.OnDeath += TankDeath;
        controller.OnAttackShot += AttackFX;
    }

    public void ShowHP(float currentHP, float maxHP)
    {
        hpBar.value = currentHP / maxHP;
    }

    public void TankDeath()
    {
        hpBar.value = 0f;
        dyingEffect.Play();
        animator.Play("Death");
    }

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
