using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private Camera _cam;
    [SerializeField] private TextMeshProUGUI text;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
        text.text = currentHealth + "/" + maxHealth;
    }

    // private void Update()
    // {
    //     transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
    // }
}
