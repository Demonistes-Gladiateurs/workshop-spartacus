using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChoices : MonoBehaviour
{
    [SerializeField] private GameObject _choicesOptions;

    [SerializeField] private GameObject _uiText;

    [SerializeField] private GameObject _questText;

    private bool _openAllowed;

    void Start()
    {
        _choicesOptions.SetActive(false);
        _uiText.SetActive(false);
    }

    public void Update()
    {
        if (_openAllowed && Input.GetKeyDown(KeyCode.E))
            OpenChoices();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            _uiText.SetActive(true);
            _openAllowed = true;
        }

        if (other.gameObject.name == "Player2")
        {
            _uiText.SetActive(true);
            _openAllowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            _uiText.SetActive(false);
            _openAllowed = false;
        }

        if (other.gameObject.name == "Player2")
        {
            _uiText.SetActive(false);
            _openAllowed = false;
        }
    }


    public void OpenChoices()
    {
        _choicesOptions.SetActive(true);
        _questText.SetActive(false);
    }


}
