﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _baseHealth = 100;
    [SerializeField] private float _bonusHealth = 0;

    [SerializeField] private float _armor = 100;

    [SerializeField] private HealthBarScript _healthBar = null;
    [SerializeField] private Slider _slider = null;

    private float _currentHealth = 100;

    private void Start()
    {
        _currentHealth = _baseHealth + _bonusHealth;
        _healthBar.SetMaxHealth(_currentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Test health bar
        {
            TakeDamage(30);
        }
    }

    private void TakeDamage(int damage)
    {
        float damageMultiplicator = 100 / (100 + _armor);

        _currentHealth = _currentHealth - (damage * damageMultiplicator);
        Debug.Log(_currentHealth);
        _healthBar.SetHealth(_currentHealth);
    }
}
