using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public void ButtonPressed()
    {
        XPManager._instance.AddXP(10);
    }
}
