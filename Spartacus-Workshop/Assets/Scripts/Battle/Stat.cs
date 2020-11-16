using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private int _baseValue;
    private List<int> _modifiers = new List<int>();
    private string _element;
    private string _effect;
    private string _type;

    public void SetElement(string modifier)
    {
        _element = modifier;
    }

    public string GetElement()
    {
        return _element;
    }

    public void SetEffect(string modifier)
    {
        _effect = modifier;
    }

    public string GetEffect()
    {
        return _effect;
    }

    public void SetTypeItem(string modifier)
    {
        _type = modifier;
    }

    public string GetTypeItem()
    {
        return _type;
    }

    public int GetValue()
    {
        int finalValue = _baseValue;
        _modifiers.ForEach(x => finalValue += x);

        return finalValue;
    }

    public void AddModifier (int modifier)
    {
        if (modifier != 0) _modifiers.Add(modifier);
    }

    public void RemoveModifier (int modifier)
    {
        if (modifier != 0) _modifiers.Remove(modifier);
    }
}
