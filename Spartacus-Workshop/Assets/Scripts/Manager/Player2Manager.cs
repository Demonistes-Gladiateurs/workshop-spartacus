using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Manager : MonoBehaviour
{
    #region Singleton

    public static Player2Manager _instance;

    private void Awake()
    {
        _instance = this;
    }

    #endregion

    [SerializeField] private GameObject _player2;

    public GameObject PlayerGS
    {
        get
        {
            return _player2;
        }
    }
}
