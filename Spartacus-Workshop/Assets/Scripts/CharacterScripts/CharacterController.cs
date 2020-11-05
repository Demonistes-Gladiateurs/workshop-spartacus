using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBoost;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    [SerializeField] private HealthBarScript _healthBar;

    private Rigidbody _rb;

    private bool _isOnTheGround = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
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

        if (Input.GetKeyDown(KeyCode.Space)) //Test health bar
        {
            TakeDamage(20);
            Debug.Log("-20");
            _healthBar.SetHealth(_currentHealth);
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

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
}
