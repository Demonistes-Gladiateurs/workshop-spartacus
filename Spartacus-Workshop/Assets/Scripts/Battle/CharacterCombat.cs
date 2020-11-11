using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private CharacterController _myStats;

    private void Start()
    {
        _myStats = GetComponent<CharacterController>();
    }

    private void Attack (CharacterController targetStats)
    {
        targetStats.TakeDamage(_myStats._damage.GetValue());
    }
}
