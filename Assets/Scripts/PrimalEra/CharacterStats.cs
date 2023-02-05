using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int hp;
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
    
}
