using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(maxHealth,health);
        if(health <= 0)
            GetComponent<PrimalAnimationController>().Dead();
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, 100);
    }
}
