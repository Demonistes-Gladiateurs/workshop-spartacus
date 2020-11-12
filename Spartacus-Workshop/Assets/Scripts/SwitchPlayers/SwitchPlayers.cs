using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour
{
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;

    [SerializeField] private GameObject _cam3;
    [SerializeField] private GameObject _cam1;

    [SerializeField] private GameObject _healthBarPlayer1;
    [SerializeField] private GameObject _healthBarPlayer2;

    [SerializeField] private GameObject _miniMapPlayer1;
    [SerializeField] private GameObject _miniMapPlayer2;

    void Start()
    {
        _player2 = GameObject.Find("Player2");
        _player1 = GameObject.Find("Player1");

        _cam3 = GameObject.Find("Camera3");
        _cam1 = GameObject.Find("Camera1");

        _cam3.SetActive(false);

        _player2.GetComponent<CharacterController>().enabled = false;

        _player2.GetComponent<FollowCharacter>().enabled = true;

        _cam1.tag = "MainCamera";
        _cam3.tag = "Camera 2";

        _healthBarPlayer1.SetActive(true);
        _healthBarPlayer2.SetActive(false);

        _miniMapPlayer1.SetActive(true);
        _miniMapPlayer2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))    //"O" for "Other" or "Other Player" 
        {
            if (_player1.GetComponent<CapsuleCollider>().enabled == true)    //collider arbitrary, but reflects object state
            {
                _player1.GetComponent<Rigidbody>().isKinematic = true;
                _player2.GetComponent<Rigidbody>().isKinematic = false;

                _player1.GetComponent<CapsuleCollider>().enabled = false;
                _player2.GetComponent<CapsuleCollider>().enabled = true;


                _player1.GetComponent<CharacterController>().enabled = false;

                _player2.GetComponent<CharacterController>().enabled = true;

                _player1.GetComponent<FollowCharacter>().enabled = true; 
                _player2.GetComponent<FollowCharacter>().enabled = false;

                _healthBarPlayer2.SetActive(true);
                _healthBarPlayer1.SetActive(false);

                _miniMapPlayer2.SetActive(true);
                _miniMapPlayer1.SetActive(false);

                _cam1.SetActive(false);

                _cam3.SetActive(true);

                _cam1.tag = "Camera 2";
                _cam3.tag = "MainCamera";
            }
        }

        if (Input.GetKeyDown(KeyCode.P))   //"P" for "Player" 
        {
            if (_player1.GetComponent<CapsuleCollider>().enabled == false)   //collider arbitrary, but reflects object state
            {
                _player1.GetComponent<Rigidbody>().isKinematic = false;
                _player2.GetComponent<Rigidbody>().isKinematic = true;

                _player1.GetComponent<CapsuleCollider>().enabled = true;
                _player2.GetComponent<CapsuleCollider>().enabled = false;


                _player1.GetComponent<CharacterController>().enabled = true;

                _player2.GetComponent<CharacterController>().enabled = false;

                _player1.GetComponent<FollowCharacter>().enabled = false;
                _player2.GetComponent<FollowCharacter>().enabled = true; ;

                _healthBarPlayer1.SetActive(true);
                _healthBarPlayer2.SetActive(false);

                _miniMapPlayer1.SetActive(true);
                _miniMapPlayer2.SetActive(false);

                _cam1.SetActive(true);
                _cam3.tag = "Camera 2";
                
                _cam1 = GameObject.Find("Camera1");
                _cam1.tag = "MainCamera";

                _cam3.SetActive(false);

            }
        }
    }
}