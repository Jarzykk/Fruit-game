using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayersBusket : MonoBehaviour, IFruitDisabler
{
    private int _fruitsCollected = 0;
    
    public event UnityAction FruitCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fruit fruit))
        {
            _fruitsCollected++;
            FruitCollected?.Invoke();
            DisableFruit(fruit);
        }
    }

    public void DisableFruit(Fruit fruit)
    {
        FruitCollected?.Invoke();
        fruit.DisableFruit();
    }
}
