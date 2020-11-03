using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBoost;

    private Rigidbody _rb;

    private bool _isOnTheGround = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
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

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal"); //Déplacements classiques
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * _speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (Input.GetButtonDown("Jump") && _isOnTheGround == true) //Saut
        {
            _rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            _isOnTheGround = false;
        }
       
    }

    private void OnCollisionEnter(Collision collision) // Si je rentre en collision avec le gameobject au nom de "Ground" alors je peux resauter
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isOnTheGround = true;
        }
    }

}
