using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _startWaitTime = 5f;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] Transform _moveSpots;



    private float _waitTime;

    void Start()
    {
        _waitTime = _startWaitTime;

        _moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveSpots.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _moveSpots.position) < 0.2f)
        {
            if (_waitTime <= 0){
                _moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                _waitTime = _startWaitTime;
            } else {
                _waitTime -= Time.deltaTime;
            }
            }
        }
        
    }

