using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _collectableTemplateToSpawn;
    [SerializeField] private GameObject _dagamebleTemplateToSpawn;
    [SerializeField] private int _damageblePerCollectable = 4;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private float _elapsedTime = 0;
    private bool _spawnIsAllowed = false;

    private void OnEnable()
    {
        _importantSceneObjects.Timer.TimerStarted += StartSpawner;
        _importantSceneObjects.Timer.TimerStopped += StopSpawner;
    }

    private void OnDisable()
    {
        _importantSceneObjects.Timer.TimerStarted -= StartSpawner;
        _importantSceneObjects.Timer.TimerStopped -= StopSpawner;
    }

    private void Start()
    {
        InitializePool();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _spawnRate && _spawnIsAllowed == true)
        {
            if (TryGetObjectFromPool(out GameObject objectToSpawn))
            {
                _elapsedTime = 0;
                Spawn(objectToSpawn);
            }
        }
    }

    private void Spawn(GameObject objectToSpawn)
    {
        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = _spawnPoints[spawnPointIndex].position;
    }

    private void StartSpawner()
    {
        _spawnIsAllowed = true;
    }

    private void StopSpawner()
    {
        _spawnIsAllowed = false;
    }

    private void InitializePool()
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (i % _damageblePerCollectable == 0)
            {
                AddObjectToPool(_dagamebleTemplateToSpawn);
            }
            else
            {
                AddObjectToPool(_collectableTemplateToSpawn);
            }
        }
    }
}
