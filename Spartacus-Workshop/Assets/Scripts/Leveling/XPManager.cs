using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XPManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentXpText, _targetXpText, _levelText;
    [SerializeField] private int _currentXP, _targetXP, _level;

    public static XPManager _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _currentXpText.text = _currentXP.ToString();
        _targetXpText.text = _targetXP.ToString();
        _levelText.text = _level.ToString();
    }

    public int AddXPInt()
    {
        AddXP(10);
        return _currentXP;
    }

    public void AddXP(int xp)
    {
        _currentXP += xp;

        //Level up
        if (_currentXP >= _targetXP)
        {
            _currentXP = _currentXP - _targetXP;
            _level++;
            _targetXP += _targetXP / 20;
            _levelText.text = _level.ToString();
            _targetXpText.text = _targetXP.ToString();
        }

        _currentXpText.text = _currentXP.ToString();
    }
}
