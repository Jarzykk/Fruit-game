using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fruit", menuName = "Fruits/Fruit", order = 51)]
public class FruitObject : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _sprite;

    public string Name => _name;
    public float Speed => _speed;
    public Sprite Sprite => _sprite;
}
