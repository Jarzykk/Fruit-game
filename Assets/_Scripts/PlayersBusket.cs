using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayersBusket : MonoBehaviour, IFruitDisabler
{
    public event UnityAction FruitCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fruit fruit))
        {
            DisableFruit(fruit);
        }
    }

    public void DisableFruit(Fruit fruit)
    {
        FruitCollected?.Invoke();
        fruit.DisableFruit();
    }
}
