using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleSpawnedObject : SpawnedObject
{
    private int _damage;

    public int Damage => _damage;

    protected override void SetDataFromObject(SpawnedScriptableObject spawnedScriptableObject)
    {
        base.SetDataFromObject(spawnedScriptableObject);
        DamageableSpawnedScriptableObject dataObject = (DamageableSpawnedScriptableObject)spawnedScriptableObject;
        _damage = dataObject.Damage;
        Debug.Log(_damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
