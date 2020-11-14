using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{
    [SerializeField] private GameObject _textBox;
    [SerializeField] private GameObject _choice01;
    [SerializeField] private GameObject _choice02;
    [SerializeField] private GameObject _armor01;
    [SerializeField] private GameObject _armor02;
   

    [SerializeField] private int _choiceMode;


    private void Start()
    {
        _armor01.SetActive(false);
        _armor02.SetActive(false);
    }

    public void ChoiceOption1()
    {
        _textBox.SetActive(false);
        _choice01.SetActive(false);
        _choice02.SetActive(false);

        _armor01.SetActive(true);
       
        _choiceMode = 1;
    }

    public void ChoiceOption2()
    {
        _textBox.SetActive(false);
        _choice01.SetActive(false);
        _choice02.SetActive(false);

        _armor02.SetActive(true);

        _choiceMode = 2;
    }

    private void Update()
    {
        if (_choiceMode >= 1)
        {
            _choice01.SetActive(false);
            _choice02.SetActive(false);
        }
    }
}
