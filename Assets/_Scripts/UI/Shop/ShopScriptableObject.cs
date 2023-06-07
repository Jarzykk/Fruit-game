using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "ScriptableObjects/ShopItem", order = 51)]
public class ShopScriptableObject : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;

    public string Title => _title;
    public Sprite Sprite => _sprite;
    public int Price => _price;
}
