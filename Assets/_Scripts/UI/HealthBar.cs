using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] _healthImage;
    [SerializeField] private SceneUI _sceneUI;
    
    private int _maxHealth = 5;

    private int _currentHealth;

    private void OnEnable()
    {
        _sceneUI.ImportantSceneObjects.Health.HealthChanged += RemoveHeartImage;
    }

    private void OnDisable()
    {
        _sceneUI.ImportantSceneObjects.Health.HealthChanged -= RemoveHeartImage;
    }

    private void RemoveHeartImage(int imageCount)
    {
        for (int i = 0; i < _healthImage.Length; i++)
        {
            if (i >= _sceneUI.ImportantSceneObjects.Health.CurrentHealth)
            {
                _healthImage[i].gameObject.SetActive(false);
            }
        }
    }
}
