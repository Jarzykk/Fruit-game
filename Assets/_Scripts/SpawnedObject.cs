using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class SpawnedObject : MonoBehaviour
{
    [SerializeField] private SpawnedScriptableObject[] _dataOfObjects;

    private string _name;
    private float _speed;
    private SpriteRenderer _spriteRenderer;

    public float Speed => _speed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        BaseOnEnable();
    }

    protected void BaseOnEnable()
    {
        SetDataFromObject(GetRandomObject());
    }

    private SpawnedScriptableObject GetRandomObject()
    {
        int randomIndex = Random.Range(0, _dataOfObjects.Length);

        return _dataOfObjects[randomIndex];
    }

    protected virtual void SetDataFromObject(SpawnedScriptableObject spawnedScriptableObject)
    {
        _name = spawnedScriptableObject.Name;
        _speed = spawnedScriptableObject.Speed;
        _spriteRenderer.sprite = spawnedScriptableObject.Sprite;
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
