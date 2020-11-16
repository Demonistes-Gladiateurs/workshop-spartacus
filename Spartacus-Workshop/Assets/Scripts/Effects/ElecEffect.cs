using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecEffect : MonoBehaviour
{
    private int _armor;
    private int _damage;
    [SerializeField] private float _timeElect;

    public void Elect(EnemyController enemy, int damage, int armor)
    {
        _armor = enemy.GetArmor();
        int _weakArmor = _armor - armor;
        enemy.SetArmor(_weakArmor);

        _damage = enemy.GetDamage();
        int _weakDamage = _damage - damage;
        enemy.SetDamage(_weakDamage);

        StartCoroutine(WaitForSeconds(enemy, _damage, _armor));
    }

    IEnumerator WaitForSeconds(EnemyController enemy, int damage, int armor)
    {
        yield return new WaitForSecondsRealtime(_timeElect);
        enemy.SetArmor(armor);
        enemy.SetDamage(damage);
    }
}
