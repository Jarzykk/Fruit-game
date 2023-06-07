using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fruit))]
public class FruitMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _elapsedTime = 0;

    private Fruit _fruit;

    private void Start()
    {
        _fruit = GetComponent<Fruit>();
        _speed = _fruit.Speed;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
    }
    
    public void DisableFruit()
    {
        gameObject.SetActive(false);
    }
}
