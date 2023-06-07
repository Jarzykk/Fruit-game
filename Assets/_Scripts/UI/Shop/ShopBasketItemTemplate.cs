using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ShopBasketItemTemplate : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _image;
    [SerializeField] private Button _buyButton;

    private int _price;

    public int Price => _price;
    public Sprite Sprite => _image.sprite;

    public event UnityAction<ShopBasketItemTemplate> BuyButtonPressed;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonPressed);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonPressed);
    }

    public void SetValues(string title, int price, Sprite sprite)
    {
        _titleText.text = title;
        _priceText.text = price.ToString();
        _price = price;
        _image.sprite = sprite;
    }

    public void SetBuyButtonInteractability(bool interactable)
    {
        _buyButton.interactable = interactable;
    }

    private void OnBuyButtonPressed()
    {
        BuyButtonPressed?.Invoke(this);
    }
}
