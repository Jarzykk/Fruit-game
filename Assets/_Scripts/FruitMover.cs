using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fruit))]
public class FruitMover : MonoBehaviour
{
    private float _elapsedTime = 0;
    private Fruit _fruit;

    private void Start()
    {
        _fruit = GetComponent<Fruit>();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (_fruit.Speed * Time.deltaTime));
    }
    
    public void DisableFruit()
    {
        gameObject.SetActive(false);
    }
}
