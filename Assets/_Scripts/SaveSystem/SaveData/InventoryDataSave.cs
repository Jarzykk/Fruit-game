using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class InventoryDataSave
{
    public List<Sprite> PurchasedSprites;
    public Sprite CurrentBasketSprite;

    public InventoryDataSave()
    {
        PurchasedSprites = new List<Sprite>();
        CurrentBasketSprite = null;
    }
}
