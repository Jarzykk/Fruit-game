using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasketTemplate : MonoBehaviour
{
    [SerializeField] protected TMP_Text _titleText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _image;
    
    private int _price;
    
    public int Price => _price;
    public Sprite Sprite => _image.sprite;
    public string Title => _titleText.text;
    
    public virtual void SetValues(string title, int price, Sprite sprite)
    {
        _titleText.text = title;
        _priceText.text = price.ToString();
        _price = price;
        _image.sprite = sprite;
    }

}
