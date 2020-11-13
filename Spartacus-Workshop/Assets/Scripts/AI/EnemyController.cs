using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _lookRadius = 10f;
    [SerializeField] private int _maxHealth = 400;
    public int _currentHealth { get; private set; }
    private int _baseDamageValue;
    private int _baseArmorValue;

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

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public int GetArmor()
    {
        return _baseArmorValue;
    }
}
