using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectsDisabled : MonoBehaviour, ISpawnedObjectsDisabled
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<SpawnedObject>(out SpawnedObject fruit))
        {
            DisableObject(fruit);
        }
    }

    public void DisableObject(SpawnedObject spawnedObject)
    {
        spawnedObject.DisableObject();
    }
}
