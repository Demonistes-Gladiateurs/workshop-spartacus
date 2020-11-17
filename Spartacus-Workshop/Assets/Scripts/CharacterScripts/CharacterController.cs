using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Transform _playerCamera;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBoost;
    [SerializeField] public string _weaponBoostName;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private EnemyController _enemy;

    [SerializeField] private ContinuedDamage _bleeding;
    [SerializeField] private FreezeEffect _freezing;
    [SerializeField] private SlowEffect _slow;
    [SerializeField] private ElecEffect _elect;

    [SerializeField] private int _maxHealth = 500;
    public int _currentHealthEnemy { get; private set; }
    public int _currentHealth;
    private int _baseDamageValue;
    private int _baseArmorValue;
    private int _baseHealValue;
    private bool _actifPlayer = false;
    private bool _canHit = false;
    private int _freezeCount;

    public Stat _damage;
    public Stat _armor;
    public Stat _heal;
    public Stat _element;

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
        _baseDamageValue = _damage.GetValue();
        _baseArmorValue = _armor.GetValue();
        _baseHealValue = _heal.GetValue();

        _currentHealthEnemy = _enemyHealth.GetCurrentHealth();
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

    private void OnTriggerStay(Collider other)
    {
        _canHit = true;
    }

    public void TakeDamage(int damage, string weaponName)
    {
        if (_canHit)
        {
            if (_playerCamera.name == "Camera1" && _playerCamera.tag == "MainCamera")
            {
                _actifPlayer = true;
            }
            else if (_playerCamera.name == "Camera2" && _playerCamera.tag == "MainCamera")
            {
                _actifPlayer = true;
            }

            if (_actifPlayer)
            {
                _currentHealthEnemy = _enemyHealth.GetCurrentHealth();
                damage -= _enemy.GetArmor();

                if (_element.GetElement() == "Fire")
                {
                    _bleeding.Bleeding(_enemyHealth, 1);
                    _bleeding.Bleeding(_enemyHealth, 2);
                    _bleeding.Bleeding(_enemyHealth, 3);
                }
                else if (_element.GetElement() == "Ice")
                {
                    _slow.SlowDown(_enemy);
                    _freezeCount += 2;
                    if (_freezeCount >= 3)
                    {
                        _freezing.Freeze(_enemy);
                        _freezeCount = 0;
                    }
                }
                else if (_element.GetElement() == "Thunder")
                {
                    _elect.Elect(_enemy, 30, 10);
                }

                if (_element.GetEffect() == "Sharp")
                {
                    _bleeding.Bleeding(_enemyHealth, 1);
                    _bleeding.Bleeding(_enemyHealth, 2);
                    _bleeding.Bleeding(_enemyHealth, 3);
                    damage += _enemy.GetArmor();
                }
                else if (_element.GetEffect() == "Blunt")
                {
                    _freezeCount++;
                    if(_freezeCount >= 3)
                    {
                        _freezing.Freeze(_enemy);
                        _freezeCount = 0;
                    }
                    damage += _enemy.GetArmor();
                }
                else if (_element.GetEffect() == "Piercing")
                {
                    //Debug.Log("Piercing !!");
                }

                damage = Mathf.Clamp(damage, 0, int.MaxValue);

                int _crit = Random.Range(1, 11);

                if (_crit == 10)
                {
                    damage *= 2;
                }

                int result = _currentHealthEnemy -= damage;

                _enemyHealth.SetCurrentHealth(result);
            }
            _actifPlayer = false;
        }
        _canHit = false;
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
        int valueToRemove = _damage.GetValue() - _baseDamageValue;
        _damage.RemoveModifier(valueToRemove);
        _damage.AddModifier(damageModifier);
        if(itemName == _weaponBoostName)
        {
            _damage.AddModifier(damageModifier);
        }
    }

    public void SetElementValue(string elementModifier)
    {
        _element.SetElement(elementModifier);
    }

    public void SetEffectValue(string effectModifier)
    {
        _element.SetEffect(effectModifier);
    }

    public void SetArmorValue(int armorModifier)
    {
        int valueToRemove = _armor.GetValue() - _baseArmorValue;
        _armor.RemoveModifier(armorModifier);
        _armor.AddModifier(armorModifier);
    }

    public void SetLifeValue(int lifeModifier)
    {
        /*int valueToRemove = _heal.GetValue() - _baseHealValue;
        _heal.AddModifier(lifeModifier);
        _currentHealthEnemy += _heal.GetValue();

        if (_currentHealthEnemy >= _maxHealth)
        {
            _currentHealthEnemy = _maxHealth;
        }
        _heal.RemoveModifier(lifeModifier);*/
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public int GetArmor()
    {
        return _baseArmorValue;
    }
}
