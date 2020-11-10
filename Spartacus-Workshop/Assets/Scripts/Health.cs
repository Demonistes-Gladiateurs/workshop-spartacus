using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int _baseHealth = 100;
    [SerializeField] private int _bonusHealth = 0;

    [SerializeField] private int _armor = 100;

    [SerializeField] private HealthBarScript _healthBar = null;
    [SerializeField] private Slider _slider = null;

    private int _currentHealth = 100;

    private void Start()
    {
        _currentHealth = _baseHealth;
        _healthBar.SetMaxHealth(_currentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Test health bar
        {
            TakeDamage(20);
            Debug.Log("-20");
        }
    }

    private void TakeDamage(int damage)
    {
        _currentHealth = _currentHealth - damage;
        _healthBar.SetHealth(_currentHealth);
    }
}
