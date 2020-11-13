using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyController _enemy1;
    [SerializeField] private HealthBarScript _healthBar;
    [SerializeField] private Slider _slider;

    private int _maxHealth;
    private int _currentHealth;

    public int CurrentHealthGS
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
        _maxHealth = _enemy1.GetMaxHealth();
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void SetCurrentHealth(int result)
    {
        Debug.Log(result);
        _currentHealth = result;
    }

    public void Update()
    {
        _healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0) //BoucleHealth
        {
            _currentHealth = _maxHealth;

        }
    }
}
