using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopManager : ShopScreen
{
    [SerializeField] private ShopScriptableObject[] _itemsToSell;
    [FormerlySerializedAs("shopBasketItemTemplate")] [SerializeField] private ShopBasketItemTemplate shopShopBasketItemTemplate;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [FormerlySerializedAs("LoadNextSceneButton")] [SerializeField] private Button _loadNextSceneButton;
    
    private ShopBasketItemTemplate[] _shopItems;

    public event UnityAction<Sprite> ItemPurchased;
    public event UnityAction Purchased;
    public event UnityAction LoadNextSceneButtonPressed;

    private void Awake()
    {
        LoadItems();
    }

    private void OnEnable()
    {
        SubscribeToItemsBuyButton();
        SetBuyButtonsInteractability();
        
        _loadNextSceneButton.onClick.AddListener(OnLoadNextSceneButtonPressed);
    }

    private void OnDisable()
    {
        UnsubscribeFromItemsBuyButton();
        
        _loadNextSceneButton.onClick.RemoveListener(OnLoadNextSceneButtonPressed);
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

    private void OnLoadNextSceneButtonPressed()
    {
        LoadNextSceneButtonPressed?.Invoke();
    }

    private void OnBuyButtonPressed(ShopBasketItemTemplate shopShopBasketItem)
    {
        if (_importantSceneObjects.PlayersMoney.TryTakeMoney(shopShopBasketItem.Price))
        {
            SetBuyButtonsInteractability();
            ItemPurchased?.Invoke(shopShopBasketItem.Sprite);
            Purchased?.Invoke();
        }
    }
}
