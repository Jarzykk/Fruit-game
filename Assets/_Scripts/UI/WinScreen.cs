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
    [SerializeField] private SceneUI _sceneUI;
    public event UnityAction ShopButtonPressed;
    public event UnityAction NextSceneButtonPressed;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonPressed);
        _shopButton.onClick.AddListener(OnShopButtonPressed);

        SetMoneyCollectedAmount();
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonPressed);
        _shopButton.onClick.RemoveListener(OnShopButtonPressed);
    }

    private void OnContinueButtonPressed()
    {
        NextSceneButtonPressed?.Invoke();
    }

    private void OnShopButtonPressed()
    {
        ShopButtonPressed?.Invoke();
    }

    private void SetMoneyCollectedAmount()
    {
        _moneyEarnedText.text = $"Money collected: {_sceneUI.ImportantSceneObjects.PlayersBusket.FruitsCollectedAmount.ToString()}";
    }
}
