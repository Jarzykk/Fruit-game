using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _templateToSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_templateToSpawn);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _spawnRate)
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
}
