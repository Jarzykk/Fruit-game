using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Inventory : UIScreen
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private InventoryItem _inventoryItemTemplate;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private Button _cancelScreenButton;

    private List<InventoryItem> _inventoryItems = new List<InventoryItem>();

    public event UnityAction<Sprite> EquipButtonPressed;
    public event UnityAction CancelScreenButtonPressed;

    private void OnEnable()
    {
        _importantSceneObjects.PlayerData.DataLoaded += LoadItems;
        _cancelScreenButton.onClick.AddListener(OnCancelScreenButtonPressed);
        
        SetBuyButtonsInteractability();
    }

    private void OnDisable()
    {
        _cancelScreenButton.onClick.RemoveListener(OnCancelScreenButtonPressed);
        
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
        for (int i = 0; i < _importantSceneObjects.InventoryData.PurchasedSprites.Count; i++)
        {
            _inventoryItems.Add(Instantiate(_inventoryItemTemplate, _conteiner));
            _inventoryItems[i].SetSprite(_importantSceneObjects.InventoryData.PurchasedSprites[i]);
        }
    }
    
    private void SetBuyButtonsInteractability()
    {
        foreach (var inventoryItem in _inventoryItems)
        {
            if(inventoryItem.Sprite == _importantSceneObjects.InventoryData.CurrentBasketSprite)
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

    private void OnCancelScreenButtonPressed()
    {
        CancelScreenButtonPressed?.Invoke();;
    }
}
