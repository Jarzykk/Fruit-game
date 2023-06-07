using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ShopManager : ShopScreen
{
    [SerializeField] private ShopScriptableObject[] _itemsToSell;
    [FormerlySerializedAs("shopBasketItemTemplate")] [SerializeField] private ShopBasketItemTemplate shopShopBasketItemTemplate;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    
    private ShopBasketItemTemplate[] _shopItems;

    public event UnityAction<Sprite> ItemPurchased;
    public event UnityAction Purchased;

    private void Awake()
    {
        LoadItems();
        SetBuyButtonsInteractability();
    }

    private void OnEnable()
    {
        SubscribeToItemsBuyButton();
    }

    private void OnDisable()
    {
        UnsubscribeFromItemsBuyButton();
    }

    private void LoadItems()
    {
        _shopItems = new ShopBasketItemTemplate[_itemsToSell.Length];
        
        for (int i = 0; i < _itemsToSell.Length; i++)
        {
            _shopItems[i] = Instantiate(shopShopBasketItemTemplate, _conteiner);
            _shopItems[i].SetValues(_itemsToSell[i].Title, _itemsToSell[i].Price, _itemsToSell[i].Sprite);
        }
    }

    private void SubscribeToItemsBuyButton()
    {
        foreach (var shopItem in _shopItems)
        {
            shopItem.BuyButtonPressed += OnBuyButtonPressed;
        }
    }
    
    private void UnsubscribeFromItemsBuyButton()
    {
        foreach (var shopItem in _shopItems)
        {
            shopItem.BuyButtonPressed -= OnBuyButtonPressed;
        }
    }

    private void SetBuyButtonsInteractability()
    {
        foreach (var shopItem in _shopItems)
        {
            if(shopItem.Price > _importantSceneObjects.PlayersMoney.MoneyAmount)
                shopItem.SetBuyButtonInteractability(false);
            else
                shopItem.SetBuyButtonInteractability(true);
        }
    }

    private void OnBuyButtonPressed(ShopBasketItemTemplate shopShopBasketItem)
    {
        if (_importantSceneObjects.PlayersMoney.TryTakeMoney(shopShopBasketItem.Price))
        {
            Debug.Log("Purchased");
            SetBuyButtonsInteractability();
            ItemPurchased?.Invoke(shopShopBasketItem.Sprite);
            Purchased?.Invoke();
        }
        Debug.Log($"Shop item's price: {shopShopBasketItem.Price}");
    }
}
