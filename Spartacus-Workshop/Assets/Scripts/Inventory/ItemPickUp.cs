using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private float _radius = 3f;
    [SerializeField] private CharacterController[] _characterController;
    [SerializeField] private HealthPlayer1 _player1;
    [SerializeField] private HealthPlayer2 _player2;

    private int player = 0;
    private int i = 0;
    private int lim = 0;
    private int maxHealth;

    public Item[] item;

    private void OnTriggerStay(Collider other)
    {
        lim = item.Length;        
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.name == "Player1")
            {
                player = 0;
                maxHealth = _characterController[0].GetMaxHealth();
            } else if (other.gameObject.name == "Player2"){
                player = 1;
                maxHealth = _characterController[1].GetMaxHealth();
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

            if(player == 0)
            {
                int actualHealth = _player1.GetCurrentHealth();
                int Heal = actualHealth + lifeModifier;
                if(Heal > maxHealth)
                {
                    Heal = maxHealth;
                }
                _player1.SetCurrentHealth(Heal);
            } else if (player == 1)
            {
                int actualHealth = _player2.GetCurrentHealth();
                int Heal = actualHealth + lifeModifier;
                if (Heal > maxHealth)
                {
                    Heal = maxHealth;
                }
                _player2.SetCurrentHealth(Heal);
            }

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
