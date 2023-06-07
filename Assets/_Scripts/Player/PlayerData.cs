using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private Sprite _defaultSprite;
    
    private List<Sprite> _purchasedSprites = new List<Sprite>();
    private Sprite _currentBasketBasketSprite;

    private int _playersMoney;

    private const string _saveKey = "PlayerDataSave";

    public int PlayersMoney => _playersMoney;
    public Sprite CurrentBasketSprite => _currentBasketBasketSprite;
    public List<Sprite> PurchasedSprites => _purchasedSprites;

    public event UnityAction DataLoaded;
    public event UnityAction<Sprite> CurrentSpriteChanged;

    private void OnEnable()
    {
        _importantSceneObjects.ShopManager.ItemPurchased += AddItemPurchasedBasketItem;
        _importantSceneObjects.Timer.TimerStopped += SavePlayerMoney;
        _importantSceneObjects.ShopManager.Purchased += SavePlayerMoney;
        _importantSceneObjects.Inventory.EquipButtonPressed += ChageCurrentSprite;
    }

    private void OnDisable()
    {
        _importantSceneObjects.ShopManager.ItemPurchased -= AddItemPurchasedBasketItem;
        _importantSceneObjects.Timer.TimerStopped -= SavePlayerMoney;
        _importantSceneObjects.ShopManager.Purchased -= SavePlayerMoney;
        _importantSceneObjects.Inventory.EquipButtonPressed -= ChageCurrentSprite;
    }

    private void Start()
    {
        Load();
        //Save();
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

    private void SavePlayerMoney()
    {
        _playersMoney = _importantSceneObjects.PlayersBasket.FruitsCollectedAmount;
        Save();
    }

    private void Load()
    {
        var saveData = SaveSystem.Load<PlayerDataSave>(_saveKey);

        _playersMoney = saveData.MoneyAmount;

        if (saveData.purchasedSprites.Count == 0 || saveData.purchasedSprites == null)
        {
            AddItemPurchasedBasketItem(_defaultSprite);
        }
        else
        {
            _purchasedSprites = saveData.purchasedSprites;
        }

        if (saveData.CurrentBasketSprite == null)
        {
            _currentBasketBasketSprite = _defaultSprite;
        }
        else
        {
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
        
        CurrentSpriteChanged?.Invoke(sprite);
    }

    private PlayerDataSave GetSaveSnapshot()
    {
        return new PlayerDataSave()
        {
            CurrentBasketSprite = _currentBasketBasketSprite,
            purchasedSprites = _purchasedSprites,
            MoneyAmount = _playersMoney
        };
    }
}
