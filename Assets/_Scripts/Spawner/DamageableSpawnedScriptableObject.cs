using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageableSpawned", menuName = "ScriptableObjects/ForSpawner/Damageable", order = 51)]
public class DamageableSpawnedScriptableObject : SpawnedScriptableObject
{
    [SerializeField] private int _damage;

    public int Damage => _damage;
}
