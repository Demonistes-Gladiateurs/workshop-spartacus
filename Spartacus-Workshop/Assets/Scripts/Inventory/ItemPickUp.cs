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
        lim = item.Length;        
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
                if(i >= lim)
                {
                    i = 0;
                }
                PickUp();
                if (i < lim)
                {
                    i++;
                }
            }
        }
    }

    void PickUp()
    {
        int damageModifier = item[i].GetDamageValue(item[i]);
        int armorModifier = item[i].GetArmorValue(item[i]);
        int lifeModifier = item[i].GetLifeValue(item[i]);
        Debug.Log("Picking up " + item[i].name + ", gdt = " + damageModifier);
        //Debug.Log("damage " + damageModifier);
        //Debug.Log("armor " + armorModifier);
        //Debug.Log("heal " + lifeModifier);
        _characterController[player].SetDamageValue(damageModifier, item[i].name);
        _characterController[player].SetArmorValue(armorModifier);
        _characterController[player].SetLifeValue(lifeModifier);
        //Destroy(gameObject);
    }

}
