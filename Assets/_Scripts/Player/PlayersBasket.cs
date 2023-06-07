using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayersBasket : MonoBehaviour, IFruitDisabler
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
        
    private int _fruitsCollectedAmount = 0;

    public int FruitsCollectedAmount => _fruitsCollectedAmount;
    
    public event UnityAction FruitCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fruit fruit))
        {
            _fruitsCollectedAmount++;
            FruitCollected?.Invoke();
            DisableFruit(fruit);
        }
    }

    public void DisableFruit(Fruit fruit)
    {
        FruitCollected?.Invoke();
        fruit.DisableFruit();
    }

    public void SetBasketSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
