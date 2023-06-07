using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDisabler : MonoBehaviour, IFruitDisabler
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Fruit>(out Fruit fruit))
        {
            DisableFruit(fruit);
        }
    }

    public void DisableFruit(Fruit fruit)
    {
        fruit.DisableFruit();
    }
}
