using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private Sprite _defaultBasketSprite;

    private List<Sprite> _purchasedBasketSprites = new List<Sprite>();
    private Sprite _currentBasketSprite;

    private void OnEnable()
    {
        _importantSceneObjects.ShopManager.Purchased += AddPurchasedBasketSprite;
    }

    private void OnDisable()
    {
        _importantSceneObjects.ShopManager.Purchased -= AddPurchasedBasketSprite;
    }

    private void Start()
    {
        _currentBasketSprite = _defaultBasketSprite;
        _importantSceneObjects.PlayersBasket.SetBasketSprite(_currentBasketSprite);
    }

    private void AddPurchasedBasketSprite(Sprite sprite)
    {
        bool itemDuplicate = false;
        
        foreach (var purchasedSprite in _purchasedBasketSprites)
        {
            if (purchasedSprite == sprite)
                itemDuplicate = true;
        }

        if (itemDuplicate == false)
        {
            _purchasedBasketSprites.Add(sprite);
            _currentBasketSprite = sprite;
            Debug.Log("Added new sprite");
        }
        else
        {
            throw new Exception("You're trying to add sprite that is already purchased");
        }
    }
}
