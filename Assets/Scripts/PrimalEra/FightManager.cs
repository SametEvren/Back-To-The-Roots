using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace PrimalEra
{
    public class FightManager : Instancable<FightManager>
    {
        public GameObject enemyHealthBar;
        public CharacterCombat characterCombat;
        public List<EnemyAI> animals;
        public List<GameObject> characterVersions;
        public List<GameObject> swordVersions;
        public int index;
        public TextMeshProUGUI name;
        public GameObject nextButton, retryButton, startAllOverButton;

        private void Start()
        {
            index = PlayerPrefs.GetInt("AnimalIndex", 0);

            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].gameObject.SetActive(false);
                characterVersions[i].gameObject.SetActive(false);
                swordVersions[i].gameObject.SetActive(false);
            }

            animals[index].gameObject.SetActive(true);
            characterVersions[index].gameObject.SetActive(true);
            swordVersions[index].gameObject.SetActive(true);
            characterCombat.enemyAI = animals[index];
            name.text = animals[index].name;
        }
        
        public void NextAnimal()
        {
            PlayerPrefs.SetInt("AnimalIndex",PlayerPrefs.GetInt("AnimalIndex",0) + 1);
            SceneManager.LoadScene("PrimalWorld");
        }

        public void Retry()
        {
            SceneManager.LoadScene("PrimalWorld");
        }

        public void StartAllOver()
        {
            SceneManager.LoadScene("Space");
        }
    }
}
