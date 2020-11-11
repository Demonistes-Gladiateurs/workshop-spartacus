using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private float _radius = 3f;
    [SerializeField] private CharacterController[] _characterController;

    private int i = 0;

    public Item item;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.name == "Player1")
            {
                i = 0;
            } else if (other.gameObject.name == "Player2"){
                i = 1;
            }
            PickUp();
        }
    }

    void PickUp()
    {
        int damageModifier = item.GetDamageValue(item);
        int armorModifier = item.GetArmorValue(item);
        int lifeModifier = item.GetLifeValue(item);
        Debug.Log("Picking up " + item.name);
        Debug.Log("damage " + damageModifier);
        Debug.Log("armor " + armorModifier);
        Debug.Log("heal " + lifeModifier);
        _characterController[i].SetDamageValue(damageModifier);
        _characterController[i].SetArmorValue(armorModifier);
        _characterController[i].SetLifeValue(lifeModifier);
        Destroy(gameObject);
    }

}
