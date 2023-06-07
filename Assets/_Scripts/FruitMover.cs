using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _elapsedTime = 0;

    private void Update()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
    }
}
