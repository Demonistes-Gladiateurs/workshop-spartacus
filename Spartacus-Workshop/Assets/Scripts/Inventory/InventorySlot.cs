using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private GameObject _icon;

    public Item ItemGS
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
        }
    }

  public void UpdateSlot ()
    {
        if (_item != null)
        {
            _icon.GetComponent<Image>().sprite = _item.IconGS;
            _icon.SetActive(true);
        }
        else
        {
            _icon.SetActive(false);
        }
    }
}
