using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnedObject))]
public class SpawnedObjectMover : MonoBehaviour
{
    private float _elapsedTime = 0;
    private SpawnedObject _spawnedObject;

    private void Start()
    {
        _spawnedObject = GetComponent<SpawnedObject>();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (_spawnedObject.Speed * Time.deltaTime));
    }
}
