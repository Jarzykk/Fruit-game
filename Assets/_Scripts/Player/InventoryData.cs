using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryData : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private Sprite _defaultSprite;
    
    private List<Sprite> _purchasedSprites;
    private Sprite _currentBasketBasketSprite;
    
    private const string _saveKey = "InventoryDataSave";
    
    public Sprite CurrentBasketSprite => _currentBasketBasketSprite;
    public List<Sprite> PurchasedSprites => _purchasedSprites;
    
    public event UnityAction DataLoaded;
    public event UnityAction<Sprite> CurrentSpriteChanged;
    
    private void Awake()
    {
        //Load();
        Save();
    }

    private void OnEnable()
    {
        _importantSceneObjects.ShopManager.ItemPurchased += AddItemPurchasedBasketItem;
        _importantSceneObjects.Inventory.EquipButtonPressed += ChageCurrentSprite;
    }

    private void OnDisable()
    {
        _importantSceneObjects.ShopManager.ItemPurchased -= AddItemPurchasedBasketItem;
        _importantSceneObjects.Inventory.EquipButtonPressed -= ChageCurrentSprite;
    }

    private void AddItemPurchasedBasketItem(Sprite sprite)
    {
        bool itemDuplicate = false;
        
        foreach (var purchasedItem in _purchasedSprites)
        {
            if (purchasedItem == sprite)
                itemDuplicate = true;
        }

        if (itemDuplicate == false)
        {
            _purchasedSprites.Add(sprite);
            ChageCurrentSprite(sprite);
            Save();
            Debug.Log("Added new sprite");
        }
        else
        {
            throw new Exception("You're trying to add sprite that is already purchased");
        }
    }

    private void Load()
    {
        var saveData = SaveSystem.Load<InventoryDataSave>(_saveKey);
        _purchasedSprites = new List<Sprite>();

        if (saveData.PurchasedSprites.Count == 0 || saveData.PurchasedSprites == null)
        {
            Debug.Log("1");
            _purchasedSprites.Add(_defaultSprite);
            _currentBasketBasketSprite = _defaultSprite;
        }
        else
        {
            Debug.Log("2");
            _purchasedSprites = saveData.PurchasedSprites;
            _currentBasketBasketSprite = saveData.CurrentBasketSprite;
        }

        DataLoaded?.Invoke();
    }

    private void Save()
    {
        SaveSystem.Save(_saveKey, GetSaveSnapshot());
    }

    private void ChageCurrentSprite(Sprite sprite)
    {
        _currentBasketBasketSprite = sprite;
        Save();
        CurrentSpriteChanged?.Invoke(sprite);
    }

    private InventoryDataSave GetSaveSnapshot()
    {
        return new InventoryDataSave()
        {
            CurrentBasketSprite = _currentBasketBasketSprite,
            PurchasedSprites = _purchasedSprites,
        };
    }
}
