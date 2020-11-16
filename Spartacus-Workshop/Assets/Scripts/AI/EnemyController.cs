﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _lookRadius = 10f;
    [SerializeField] private int _maxHealth = 400;
    [SerializeField] private CharacterController[] _playerList;
    [SerializeField] private HealthPlayer1 _healthPlayer1;
    [SerializeField] private HealthPlayer2 _healthPlayer2;

    public int _currentHealth { get; private set; }
    private int _baseDamageValue;
    private int _baseArmorValue;
    private int _damageHit;
    private int _result;
    private int _player1Health;
    private int _player2Health;
    private float _timer;
    private float _maxTimer = 1.0f;

    private int i;

    private Transform _target;
    private NavMeshAgent _agent;

    public Stat _damage;
    public Stat _armor;

    private void Start()
    {
        _target = PlayerManager._instance.PlayerGS.transform;
        _agent = GetComponent<NavMeshAgent>();
        _currentHealth = _maxHealth;
        _baseDamageValue = _damage.GetValue();
        _baseArmorValue = _armor.GetValue();
    }

    private void Update()
    {
        float distance = Vector3.Distance(_target.position, transform.position);

        if (distance <= _lookRadius)
        {
            _agent.SetDestination(_target.position);

            if (distance <= _agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    public float SpeedGS
    {
        get
        {
            return GetComponent<NavMeshAgent>().speed;
        }
        set
        {
            GetComponent<NavMeshAgent>().speed = value;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
    }

    private void OnTriggerStay(Collider other)
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _player1Health = _healthPlayer1.GetCurrentHealth();
            _player2Health = _healthPlayer2.GetCurrentHealth();
            if (other.gameObject.tag == "Player")
            {
                _damageHit = _baseDamageValue;
                if (other.gameObject.name == "Player1")
                {
                    i = 0;
                    _damageHit -= _playerList[i].GetArmor();
                    _damageHit = Mathf.Clamp(_damageHit, 0, int.MaxValue);
                    _result = _player1Health -= _damageHit;
                    _player1Health -= _damageHit;
                    _healthPlayer1.SetCurrentHealth(_result);
                }
                else if (other.gameObject.name == "Player2")
                {
                    i = 1;
                    _damageHit -= _playerList[i].GetArmor();
                    _damageHit = Mathf.Clamp(_damageHit, 0, int.MaxValue);
                    _result = _player2Health -= _damageHit;
                    _player2Health -= _damageHit;
                    _healthPlayer2.SetCurrentHealth(_result);
                }
            }
            _timer = _maxTimer;
        }
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public int GetArmor()
    {
        return _baseArmorValue;
    }

    public void SetArmor(int armor)
    {
        _baseArmorValue = armor;
    }

    public int GetDamage()
    {
        return _baseDamageValue;
    }

    public void SetDamage(int damage)
    {
        _baseDamageValue = damage;
    }
}
