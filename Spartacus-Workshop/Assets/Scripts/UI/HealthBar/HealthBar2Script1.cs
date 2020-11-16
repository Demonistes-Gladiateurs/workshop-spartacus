using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar2Script1 : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMaxHealth(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void SetHealth(float health)
    {
        _slider.value = health;
    }
}
