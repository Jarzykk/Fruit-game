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
    
    private List<ShopBasketItemTemplate> _shopGoods = new List<ShopBasketItemTemplate>();

    public event UnityAction<Sprite> ItemPurchased;
    public event UnityAction Purchased;
    public event UnityAction LoadNextSceneButtonPressed;

    private void Awake()
    {
        //LoadItems();
    }

    private void OnEnable()
    {
        LoadItems();
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
        for (int i = 0; i < _itemsToSell.Length; i++)
        {
            bool playerHasItem = false;
            
            for (int j = 0; j < _importantSceneObjects.PlayerData.PurchasedSprites.Count; j++)
            {
                if (_importantSceneObjects.PlayerData.PurchasedSprites[j].name == _itemsToSell[i].Sprite.name)
                {
                    playerHasItem = true;
                }
            }

            if (playerHasItem == false)
            {
                _shopGoods.Add(Instantiate(shopShopBasketItemTemplate, _conteiner));
                _shopGoods[i].SetValues(_itemsToSell[i].Title, _itemsToSell[i].Price, _itemsToSell[i].Sprite);
            }
        }
    }

    private void SubscribeToItemsBuyButton()
    {
        foreach (var shopItem in _shopGoods)
        {
            shopItem.BuyButtonPressed += OnBuyButtonPressed;
        }
    }
    
    private void UnsubscribeFromItemsBuyButton()
    {
        foreach (var shopItem in _shopGoods)
        {
            shopItem.BuyButtonPressed -= OnBuyButtonPressed;
        }
    }

    private void SetBuyButtonsInteractability()
    {
        foreach (var shopItem in _shopGoods)
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
