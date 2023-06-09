using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WinScreen : UIScreen
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private TMP_Text _moneyEarnedText;
    [SerializeField] private TMP_Text _totalMoneyAmount;
    [SerializeField] private SceneUI _sceneUI;
    public event UnityAction ShopButtonPressed;
    public event UnityAction NextSceneButtonPressed;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonPressed);
        _shopButton.onClick.AddListener(OnShopButtonPressed);

        _sceneUI.ImportantSceneObjects.PlayersMoney.MoneyAmountChanged += OnPlayerAmountChanged;

        SetMoneyAmount();
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonPressed);
        _shopButton.onClick.RemoveListener(OnShopButtonPressed);
        
        _sceneUI.ImportantSceneObjects.PlayersMoney.MoneyAmountChanged -= OnPlayerAmountChanged;
    }

    private void OnContinueButtonPressed()
    {
        NextSceneButtonPressed?.Invoke();
    }

    private void OnShopButtonPressed()
    {
        ShopButtonPressed?.Invoke();
    }

    private void OnPlayerAmountChanged(int money)
    {
        _totalMoneyAmount.text = $"Total money: {_sceneUI.ImportantSceneObjects.PlayersMoney.MoneyAmount}";
    }

    private void SetMoneyAmount()
    {
        _moneyEarnedText.text = $"Money collected: {_sceneUI.ImportantSceneObjects.PlayersBasket.FruitsCollectedAmount.ToString()}";
        _totalMoneyAmount.text = $"Total money: {_sceneUI.ImportantSceneObjects.PlayersMoney.MoneyAmount}";
    }
}
