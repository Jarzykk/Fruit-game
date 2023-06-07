using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class Fruit : MonoBehaviour
{
    [SerializeField] private FruitObject[] _fruitObjects;

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

    private FruitObject GetRandomFruitObject()
    {
        int randomIndex = Random.Range(0, _fruitObjects.Length);

        return _fruitObjects[randomIndex];
    }

    private void SetDataFromFruitObject(FruitObject fruitObject)
    {
        _name = fruitObject.Name;
        _speed = fruitObject.Speed;
        _spriteRenderer.sprite = fruitObject.Sprite;
    }

    public void DisableFruit()
    {
        gameObject.SetActive(false);
    }
}
