using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Transform _playerCamera;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBoost;
    [SerializeField] public string _weaponBoostName;

    [SerializeField] private int _maxHealth = 500;
    public int _currentHealth { get; private set; }

    public Stat _damage;
    public Stat _armor;
    public Stat _heal;

    private Rigidbody _rb;

    //private bool _isOnTheGround = true;

        public float SpeedGS
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
    }

    void Update()
    {
        PlayerMovement(); //Joue la fonction PlayerMovement

        if(Input.GetKeyDown(KeyCode.LeftShift)) //Sprint
        {
            _speed += _speedBoost;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed -= _speedBoost;
        }
    }

    public void TakeDamage(int damage, string weaponName)
    {
        if(_playerCamera.name == "Camera1" && _playerCamera.tag == "MainCamera")
        {
            _currentHealth = GetComponent<HealthPlayer1>().CurrentHealthGS;
        } else if (_playerCamera.name == "Camera2" && _playerCamera.tag == "MainCamera")
        {
            _currentHealth = GetComponent<HealthPlayer2>().CurrentHealthGS;
        }

        if (weaponName != "Spear")
        {
            damage -= _armor.GetValue();
        }
        
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        int _crit = Random.Range(1, 11);

        if(_crit == 10)
        {
            damage *= 2;
        }

        int result = _currentHealth -= damage;

        if (_playerCamera.name == "Camera1" && _playerCamera.tag == "MainCamera")
        {
            GetComponent<HealthPlayer1>().CurrentHealthGS = result;
            Debug.Log(transform.name + " takes " + damage + " damages.");
        }
        else if (_playerCamera.name == "Camera2" && _playerCamera.tag == "MainCamera")
        {
            GetComponent<HealthPlayer2>().CurrentHealthGS = result;
            Debug.Log(transform.name + " takes " + damage + " damages.");
        }

        if (_currentHealth <= 0)
        {
            Debug.Log("DEAD");
        }
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal"); //Déplacements classiques
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * _speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
       
    }

    public void SetDamageValue(int damageModifier, string itemName)
    {
        _damage.RemoveModifier(damageModifier);
        _damage.AddModifier(damageModifier);
        if(itemName == _weaponBoostName)
        {
            _damage.AddModifier(damageModifier);
        }
        Debug.Log(_damage.GetValue());
    }

    public void SetArmorValue(int armorModifier)
    {
        _armor.RemoveModifier(armorModifier);
        _armor.AddModifier(armorModifier);
        Debug.Log(_armor.GetValue());
    }

    public void SetLifeValue(int lifeModifier)
    {
        _heal.AddModifier(lifeModifier);
        _currentHealth += _heal.GetValue();

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        Debug.Log(_heal.GetValue());
        Debug.Log(_currentHealth);
        _heal.RemoveModifier(lifeModifier);
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }
}
