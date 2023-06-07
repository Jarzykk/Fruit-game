using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Fruit _templateToSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _spawnRate)
        {
            _elapsedTime = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
        Instantiate(_templateToSpawn, _spawnPoints[spawnPointIndex]);
    }
}
