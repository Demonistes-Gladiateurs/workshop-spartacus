using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer2 : MonoBehaviour
{
    [SerializeField] private float _baseHealth = 100;
    [SerializeField] private float _bonusHealth = 0;

    [SerializeField] private float _armor = 100;

    [SerializeField] private HealthBar2Script1 _healthBar = null;
    [SerializeField] private Slider _slider = null;

    private float _currentHealth = 100;

    public float CurrentHealthGS
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    private void Start()
    {
        _currentHealth = _baseHealth + _bonusHealth;
        _healthBar.SetMaxHealth(_currentHealth);
    }

    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space)) //Test health bar
        {
            TakeDamage(30);
        }*/

        if (_currentHealth <= 0) //BoucleHealth
        {
            _currentHealth = _baseHealth;
        }
    }

   /* private void TakeDamage(int damage) 
    {
        float damageMultiplicator = 100 / (100 + _armor);

        _currentHealth = _currentHealth - (damage * damageMultiplicator);
        Debug.Log(_currentHealth);
        _healthBar.SetHealth(_currentHealth);
    } */
}
