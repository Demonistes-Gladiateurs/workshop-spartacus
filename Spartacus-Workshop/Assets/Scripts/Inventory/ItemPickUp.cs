using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private float _radius = 3f;
    [SerializeField] private CharacterController[] _characterController;

    private int player = 0;
    private int i = 0;
    private int lim = 0;

    public Item[] item;

    private void OnTriggerStay(Collider other)
    {
        lim = item.Length - 1;        
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.name == "Player1")
            {
                player = 0;
            } else if (other.gameObject.name == "Player2"){
                player = 1;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                PickUp();
                if (i < lim)
                {
                    i++;
                }
                else i=0;
            }
        }
    }

    void PickUp()
    {
        Debug.Log("pickup " + i);
        int damageModifier = item[i].GetDamageValue(item[i]);
        int armorModifier = item[i].GetArmorValue(item[i]);
        int lifeModifier = item[i].GetLifeValue(item[i]);
        Debug.Log("Picking up " + item[i].name + ", gdt = " + damageModifier);
        //Debug.Log("damage " + damageModifier);
        //Debug.Log("armor " + armorModifier);
        //Debug.Log("heal " + lifeModifier);
        Debug.Log("pickup PREBUG " + i);
        _characterController[i].SetDamageValue(damageModifier, item[i].name);
        _characterController[i].SetArmorValue(armorModifier);
        _characterController[i].SetLifeValue(lifeModifier);
        //Destroy(gameObject);
    }

}
