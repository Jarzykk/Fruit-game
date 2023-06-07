using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class Fruit : MonoBehaviour
{
    [SerializeField] private FruitScriptableObject[] _fruitObjects;

    private string _name;
    private float _speed;
    private SpriteRenderer _spriteRenderer;

    public float Speed => _speed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        SetDataFromFruitObject(GetRandomFruitObject());
    }

    private FruitScriptableObject GetRandomFruitObject()
    {
        int randomIndex = Random.Range(0, _fruitObjects.Length);

        return _fruitObjects[randomIndex];
    }

    private void SetDataFromFruitObject(FruitScriptableObject fruitScriptableObject)
    {
        _name = fruitScriptableObject.Name;
        _speed = fruitScriptableObject.Speed;
        _spriteRenderer.sprite = fruitScriptableObject.Sprite;
    }

    public void DisableFruit()
    {
        gameObject.SetActive(false);
    }
}
