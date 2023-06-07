using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerDataSave
{
    public List<Sprite> purchasedSprites;
    public Sprite CurrentBasketSprite;
    public int MoneyAmount;

    public PlayerDataSave()
    {
        purchasedSprites = new List<Sprite>();
        CurrentBasketSprite = null;
        MoneyAmount = 0;
    }
}
