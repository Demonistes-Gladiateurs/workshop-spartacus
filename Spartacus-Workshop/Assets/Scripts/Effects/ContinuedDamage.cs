using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuedDamage : MonoBehaviour

{
    [SerializeField] private int _continiousDamages;
    private int _health;

    public void Bleeding(EnemyHealth enemyHealth, int time)
    {
        _health = enemyHealth.GetCurrentHealth();
        StartCoroutine(WaitForSeconds(enemyHealth, time));
    }

    IEnumerator WaitForSeconds(EnemyHealth enemyHealth, int time)
    {
        yield return new WaitForSecondsRealtime(time);
        _health -= _continiousDamages;
        enemyHealth.SetCurrentHealth(_health);
        Debug.Log(_health + " SANG");
    }
}
