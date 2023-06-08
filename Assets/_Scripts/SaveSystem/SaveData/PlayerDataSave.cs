using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerDataSave
{
    public int MoneyAmount;

    public PlayerDataSave()
    {
        MoneyAmount = 0;
    }
}
