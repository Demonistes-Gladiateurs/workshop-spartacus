/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    [SerializeField] private float _slowValue = 3f;
    [SerializeField] private float _slowDelay = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    IEnumerator Slow(GameObject Go)
    {
        float val;
        if(Go.gameObject.tag == "Player 1 || Player 2")
        {
            val = Go.GetComponent<CharacterController>().SpeedGS;
            Go.GetComponent<CharacterController>().SpeedGS -= _slowValue;
            Debug.Log("Slow activated");
            yield return new WaitForSeconds(_slowDelay);
            Debug.Log("Slow desactivated");
            Go.GetComponent<CharacterController>().SpeedGS = val;
        }
    }
}*/
