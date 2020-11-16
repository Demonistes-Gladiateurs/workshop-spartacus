using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEffect : MonoBehaviour
{
    public void Freeze(EnemyController enemy)
    {
        enemy.GetComponent<EnemyController>().enabled = false;
        enemy.GetComponent<EnemyController>().SpeedGS = 0;
        Debug.Log("Freeze");
        StartCoroutine(WaitForSeconds(enemy));
    }

    IEnumerator WaitForSeconds(EnemyController enemy)
    {
        yield return new WaitForSecondsRealtime(2);
        enemy.GetComponent<EnemyController>().enabled = true;
        enemy.GetComponent<EnemyController>().SpeedGS = 2;
        Debug.Log("CharacterController activé");
    }
}
