using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer1 : MonoBehaviour
{
    [SerializeField] private CharacterController _character1;
    [SerializeField] private HealthBarScript _healthBar = null;
    [SerializeField] private Slider _slider = null;

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

    public void SetCurrentHealth(int result)
    {
        _currentHealth = result;
        //Debug.Log(_currentHealth);
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    private void Start()
    {
        _maxHealth = _character1.GetMaxHealth();
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        _healthBar.SetHealth(_currentHealth);
        if (Input.GetKeyDown(KeyCode.Space)) //Test health bar
        {
            _character1.TakeDamage(_character1._damage.GetValue(), _character1._weaponBoostName);
            _healthBar.SetHealth(_currentHealth);
        }

        if (_currentHealth <= 0) //BoucleHealth
        {
            _currentHealth = _maxHealth;
        }
    }
}
