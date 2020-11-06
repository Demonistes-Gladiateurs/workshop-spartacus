﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _itemName = "New Item";
    [SerializeField] private string _itemDescription = "New Description";
    [SerializeField] private Sprite _icon;

    //[SerializeField] private int _price = 0;
    
    [SerializeField] private enum Type { Default, Consumable, Weapon, Ammunition}

    [SerializeField] private Type _type = Type.Default;

    public Sprite IconGS
    {
        get
        {
            return _icon;
        }
    }
}