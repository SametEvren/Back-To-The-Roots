using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrimalEra
{
    public class FightManager : MonoBehaviour
    {
        public GameObject enemyHealthBar;
        public CharacterCombat characterCombat;
        public List<EnemyAI> animals;
        public int index;

        private void Start()
        {
            index = PlayerPrefs.GetInt("AnimalIndex", 0);
            
            foreach (var animal in animals)
            {
                animal.gameObject.SetActive(false);
            }

            animals[index].gameObject.SetActive(true);
            characterCombat.enemyAI = animals[index];
        }
    }
}
