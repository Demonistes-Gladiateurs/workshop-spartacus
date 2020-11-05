using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    #endregion

    [SerializeField] private GameObject _player;

    public GameObject PlayerGS
    {
        get
        {
            return _player;
        }
    }
}
