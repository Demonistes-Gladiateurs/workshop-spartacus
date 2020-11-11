using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderKillPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        _player.transform.position = _respawnPoint.transform.position;
    }
}
