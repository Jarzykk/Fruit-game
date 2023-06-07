using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : UIScreen
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private InventoryItem _inventoryItemTemplate;
    [SerializeField] private Transform _conteiner;

    private List<InventoryItem> _inventoryItems = new List<InventoryItem>();

    public event UnityAction<Sprite> EquipButtonPressed;

    private void OnEnable()
    {
        _importantSceneObjects.PlayerData.DataLoaded += LoadItems;
        
        SetBuyButtonsInteractability();
    }

    private void OnDisable()
    {
        UnsubscribeFromEquipButtons();
        _importantSceneObjects.PlayerData.DataLoaded -= LoadItems;
    }

    private void Start()
    {
        LoadItems();
        SubscribeToEquipButtons();
        SetBuyButtonsInteractability();
    }

    private void LoadItems()
    {
        for (int i = 0; i < _importantSceneObjects.PlayerData.PurchasedSprites.Count; i++)
        {
            _inventoryItems.Add(Instantiate(_inventoryItemTemplate, _conteiner));
            _inventoryItems[i].SetSprite(_importantSceneObjects.PlayerData.PurchasedSprites[i]);
        }
    }
    
    private void SetBuyButtonsInteractability()
    {
        foreach (var inventoryItem in _inventoryItems)
        {
            if(inventoryItem.Sprite == _importantSceneObjects.PlayerData.CurrentBasketSprite)
                inventoryItem.SetEquipButtonInteractability(false);
            else
                inventoryItem.SetEquipButtonInteractability(true);
        }
    }

    private void SubscribeToEquipButtons()
    {
        foreach (var item in _inventoryItems)
        {
            item.EquipButtonPressed += OnEquipButtonPressed;
        }
    }

    private void UnsubscribeFromEquipButtons()
    {
        foreach (var item in _inventoryItems)
        {
            item.EquipButtonPressed -= OnEquipButtonPressed;
        }
    }

    private void OnEquipButtonPressed(Sprite sprite)
    {
        Debug.Log("Pressed");
        EquipButtonPressed?.Invoke(sprite);
        SetBuyButtonsInteractability();
    }
}
