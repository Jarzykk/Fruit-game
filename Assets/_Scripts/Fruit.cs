using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : SpawnedObject, ICollecteable
{
    public void CollectMe()
    {
        DisableObject();
    }
}
