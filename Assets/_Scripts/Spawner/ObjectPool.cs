using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject Container;
    [SerializeField] protected int Capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void AddObjectToPool(GameObject prefub)
    {
        GameObject spawned = Instantiate(prefub, Container.transform);
        spawned.SetActive(false);
        _pool.Add(spawned);
    }

    protected bool TryGetObjectFromPool(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }
}