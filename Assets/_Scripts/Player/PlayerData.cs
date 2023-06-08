using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private int _playersMoney;

    private const string _saveKey = "SavePlayerData";

    public int PlayersMoney => _playersMoney;

    public event UnityAction DataLoaded;

    private void Awake()
    {
        Load();
        //Save();
    }

    private void OnEnable()
    {
        _importantSceneObjects.PlayersMoney.MoneyAmountChanged += SavePlayerMoney;
    }

    private void OnDisable()
    {
        _importantSceneObjects.PlayersMoney.MoneyAmountChanged -= SavePlayerMoney;
    }

    private void SavePlayerMoney(int money)
    {
        _playersMoney = money;
        Save();
    }

    private void Load()
    {
        var saveData = SaveSystem.Load<PlayerDataSave>(_saveKey);

        _playersMoney = saveData.MoneyAmount;

        DataLoaded?.Invoke();
    }

    private void Save()
    {
        SaveSystem.Save(_saveKey, GetSaveSnapshot());
    }

    private PlayerDataSave GetSaveSnapshot()
    {
        return new PlayerDataSave()
        {
            MoneyAmount = _playersMoney
        };
    }
}
