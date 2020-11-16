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
        string typeOfItem = item[i].GetTypeValue(item[i]);

        if(typeOfItem == "Consumable")
        {
            int lifeModifier = item[i].GetLifeValue(item[i]);
            _characterController[player].SetLifeValue(lifeModifier);

            Debug.Log("Soin de: " + lifeModifier);

        } else if (typeOfItem == "Weapon")
        {
            string effectModifier = item[i].GetEffectValue(item[i]);
            int damageModifier = item[i].GetDamageValue(item[i]);

            _characterController[player].SetEffectValue(effectModifier);
            _characterController[player].SetDamageValue(damageModifier, item[i].name);

            Debug.Log(item[i].name + " + " + damageModifier + " dgt de type " + effectModifier);

        } else if (typeOfItem == "Armor")
        {
            int armorModifier = item[i].GetArmorValue(item[i]);
            _characterController[player].SetArmorValue(armorModifier);

            Debug.Log("Défense de: " + armorModifier);

        } else if (typeOfItem == "Element")
        {
            string elementModifier = item[i].GetElementValue(item[i]);
            _characterController[player].SetElementValue(elementModifier);

            Debug.Log("Prend l'élément: " + elementModifier);
        }
        //Destroy(gameObject);
    }

}
