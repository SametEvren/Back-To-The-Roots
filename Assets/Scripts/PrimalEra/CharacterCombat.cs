using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public EnemyAI enemyAI;
    public int strength;
    public bool enemyIn;
    private void OnTriggerEnter(Collider other)
    {
        enemyIn = other.CompareTag("Enemy");
    }

    public void AttackEnemy()
    {
        if(enemyIn)
            enemyAI.TakeDamage(strength);
    }
}
