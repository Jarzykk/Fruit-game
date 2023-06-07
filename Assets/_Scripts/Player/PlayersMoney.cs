using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayersMoney : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    
    private int _moneyAmount;

    public int MoneyAmount => _moneyAmount;

    public event UnityAction<int> MoneyAmountChanged;

    private void OnEnable()
    {
        _importantSceneObjects.Timer.TimerStopped += OnGameTimerStopped;
    }

    private void OnDisable()
    {
        _importantSceneObjects.Timer.TimerStopped -= OnGameTimerStopped;
    }

    public void AddMoney(int amount)
    {
        _moneyAmount += amount;
        MoneyAmountChanged?.Invoke(_moneyAmount);
    }

    public bool TryTakeMoney(int amount)
    {
        if (_moneyAmount - amount >= 0)
        {
            _moneyAmount -= amount;
            MoneyAmountChanged?.Invoke(_moneyAmount);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnGameTimerStopped()
    {
        AddMoney(_importantSceneObjects.PlayersBasket.FruitsCollectedAmount);
    }
}
