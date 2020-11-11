using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _itemName = "New Item";
    [SerializeField] private string _itemDescription = "New Description";
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _damageModifier = 0;
    [SerializeField] private int _armorModifier = 0;
    [SerializeField] private int _lifeModifier = 0;

    //[SerializeField] private int _price = 0;

    [SerializeField] private enum Type { Default, Consumable, Weapon, Ammunition }
    [SerializeField] private enum Effect { Default, Sharp, Blunt, Piercing }
    [SerializeField] private enum Element { Default, Fire, Ice, Thunder }

    [SerializeField] private Type _type = Type.Default;
    [SerializeField] private Effect _effect = Effect.Default;
    [SerializeField] private Element _element = Element.Default;

    public Sprite IconGS
    {
        get
        {
            return _icon;
        }
    }

    public int GetDamageValue(Item item)
    {
        return _damageModifier;
    }

    public int GetArmorValue(Item item)
    {
        return _armorModifier;
    }

    public int GetLifeValue(Item item)
    {
        return _lifeModifier;
    }
}
