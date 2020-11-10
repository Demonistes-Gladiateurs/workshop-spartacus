using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject cam3;
    public GameObject cam1;

    void Start()
    {
        player2 = GameObject.Find("Player2");
        player1 = GameObject.Find("Player1");

        cam3 = GameObject.Find("Camera3");
        cam1 = GameObject.Find("Camera1");



        cam3.SetActive(false);

        player2.GetComponent<CharacterController>().enabled = false;

        player2.GetComponent<FollowCharacter>().enabled = true;

        cam1.tag = "MainCamera";
        cam3.tag = "Camera 2";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))    //"O" for "Other" or "Other Player" 
        {
            if (player1.GetComponent<CapsuleCollider>().enabled == true)    //collider arbitrary, but reflects object state
            {
                player1.GetComponent<Rigidbody>().isKinematic = true;
                player2.GetComponent<Rigidbody>().isKinematic = false;

                player1.GetComponent<CapsuleCollider>().enabled = false;
                player2.GetComponent<CapsuleCollider>().enabled = true;


                player1.GetComponent<CharacterController>().enabled = false;

                player2.GetComponent<CharacterController>().enabled = true;

                player1.GetComponent<FollowCharacter>().enabled = true;
                player2.GetComponent<FollowCharacter>().enabled = false;

                cam1.SetActive(false);

                cam3.SetActive(true);

                cam1.tag = "Camera 2";
                cam3.tag = "MainCamera";
            }
        }

        if (Input.GetKeyDown(KeyCode.P))   //"P" for "Player" 
        {
            if (player1.GetComponent<CapsuleCollider>().enabled == false)   //collider arbitrary, but reflects object state
            {
                player1.GetComponent<Rigidbody>().isKinematic = false;
                player2.GetComponent<Rigidbody>().isKinematic = true;

                player1.GetComponent<CapsuleCollider>().enabled = true;
                player2.GetComponent<CapsuleCollider>().enabled = false;

                // player1.GetComponent<ThirdPersonCharacter>().enabled = true;
                player1.GetComponent<CharacterController>().enabled = true;

                // player2.GetComponent<ThirdPersonCharacter>().enabled = false;
                player2.GetComponent<CharacterController>().enabled = false;

                player1.GetComponent<FollowCharacter>().enabled = false;
                player2.GetComponent<FollowCharacter>().enabled = true; ;

                cam1.SetActive(true);
                cam3.tag = "Camera 2";

                cam1 = GameObject.Find("Camera1");
                cam1.tag = "MainCamera";

                cam3.SetActive(false);

            }
        }
    }
}