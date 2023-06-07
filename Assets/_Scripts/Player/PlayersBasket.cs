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
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
        
    private int _fruitsCollectedAmount = 0;
    private bool _canCollect = true;

    public int FruitsCollectedAmount => _fruitsCollectedAmount;
    
    public event UnityAction FruitCollected;

    private void OnEnable()
    {
        _importantSceneObjects.PlayerData.DataLoaded += SetLoadedSprite;
        _importantSceneObjects.PlayerData.CurrentSpriteChanged += SetBasketSprite;
        _importantSceneObjects.Timer.TimerStopped += OnTimerStopped;
    }

    private void OnDisable()
    {
        _importantSceneObjects.PlayerData.DataLoaded -= SetLoadedSprite;
        _importantSceneObjects.PlayerData.CurrentSpriteChanged -= SetBasketSprite;
        _importantSceneObjects.Timer.TimerStopped -= OnTimerStopped;
    }

    private void Start()
    {
        SetLoadedSprite();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fruit fruit))
        {
            if(_canCollect == false)
                return;
            
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

    private void SetLoadedSprite()
    {
        _spriteRenderer.sprite = _importantSceneObjects.PlayerData.CurrentBasketSprite;
    }

    private void OnTimerStopped()
    {
        _canCollect = false;
    }
}
