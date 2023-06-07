using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsBar : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private TMP_Text _moneyAmountText;

    private void OnEnable()
    {
        _importantSceneObjects.PlayersBasket.FruitCollected += ChangeMoneyAmountByCollectedFruits;
        _importantSceneObjects.PlayersMoney.MoneyAmountChanged += SetTotalMoneyAmount;
    }

    private void OnDisable()
    {
        _importantSceneObjects.PlayersBasket.FruitCollected -= ChangeMoneyAmountByCollectedFruits;
        _importantSceneObjects.PlayersMoney.MoneyAmountChanged -= SetTotalMoneyAmount;
    }

    private void Start()
    {
        ChangeMoneyAmountByCollectedFruits();
    }

    private void ChangeMoneyAmountByCollectedFruits()
    {
        _moneyAmountText.text = _importantSceneObjects.PlayersBasket.FruitsCollectedAmount.ToString();
    }

    private void SetTotalMoneyAmount(int money)
    {
        _moneyAmountText.text = money.ToString();
    }
}
