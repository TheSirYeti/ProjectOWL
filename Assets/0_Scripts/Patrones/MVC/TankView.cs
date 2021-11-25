using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private ParticleSystem shootingSmoke, dyingEffect;
    private Animator animator;
    private Slider hpBar;

    private TankModel model;

    public TankView(ParticleSystem shootingSmoke, ParticleSystem dyingEffect, Slider hpBar, TankModel model, Animator animator)
    {
        this.shootingSmoke = shootingSmoke;
        this.dyingEffect = dyingEffect;
        this.hpBar = hpBar;
        this.model = model;
        this.animator = animator;
        
        model.OnDamageRecieved += ShowHP;
        model.OnDeath += TankDeath;
        model.OnAttackShot += AttackFX;
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
