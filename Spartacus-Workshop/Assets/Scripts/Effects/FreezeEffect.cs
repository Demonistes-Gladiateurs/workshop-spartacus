/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEffect : MonoBehaviour
{
    [SerializeField] private float _freezeDelay = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    IEnumerator Freeze(GameObject Go)
    {
        if(Go.gameObject.tag == "Player 1 || Player 2")
        {
            Go.GetComponent<CharacterController>().enabled = false;
            Debug.Log("CharacterController desactivé");
            yield return new WaitForSeconds(_freezeDelay);
            Go.GetComponent<CharacterController>().enabled = true;
            Debug.Log("CharacterController activé");
        }
    }
}*/
