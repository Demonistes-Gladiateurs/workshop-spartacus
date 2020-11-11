using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBoost;
    [SerializeField] private string _weaponBoostName;

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

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= _armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        int _crit = Random.Range(1, 11);

        if(_crit == 10)
        {
            damage *= 2;
        }

        _currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damages.");

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

        /*if (Input.GetButtonDown("Jump") && _isOnTheGround == true) //Saut
        {
            _rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            _isOnTheGround = false;
        }*/
       
    }

    /* private void OnCollisionEnter(Collision collision) // Si je rentre en collision avec le gameobject au nom de "Ground" alors je peux resauter
     {
         if (collision.gameObject.tag == "Ground")
         {
             _isOnTheGround = true;
         }
     }*/

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
}
