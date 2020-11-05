using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _targetDistance;
    [SerializeField] private float _allowedDistance = 5f;
    [SerializeField] private GameObject _ai;
    [SerializeField] private float _followSpeed;
    [SerializeField] RaycastHit _shot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _shot))
        {
            _targetDistance = _shot.distance;
            if(_targetDistance >= _allowedDistance)
            {
                _followSpeed = 0.02f;
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _followSpeed);

            }
        }
    }
}
