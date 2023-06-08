using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviour, Idamageable
{
    private int _maxHealth = 5;

    private int _currentHealth;
    private bool _isDead = false;

    public int CurrentHealth => _currentHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(_isDead)
            return;
        
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            _isDead = true;
            _currentHealth = 0;
            Debug.Log("Died");
            Died?.Invoke();
        }
    }
}
