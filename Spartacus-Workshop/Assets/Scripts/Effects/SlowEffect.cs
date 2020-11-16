using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    private float _slowValue = 1f;
    [SerializeField] private float _slowDelay;

    public void SlowDown(EnemyController enemy)
    {
        float val;
        val = enemy.GetComponent<EnemyController>().SpeedGS;
        Debug.Log(val);
        if (val >= 2)
        {
            enemy.GetComponent<EnemyController>().SpeedGS -= _slowValue;
        }
        //Debug.Log("Slow activated " + enemy.GetComponent<EnemyController>().SpeedGS);
        StartCoroutine(Slow(enemy, 2));
    }

    IEnumerator Slow(EnemyController enemy, float val)
    {
        yield return new WaitForSeconds(_slowDelay);
        //Debug.Log("Slow desactivated");
        enemy.GetComponent<EnemyController>().SpeedGS = val;
    }
}
