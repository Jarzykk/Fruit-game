using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _equipButton;

    public Sprite Sprite => _image.sprite;

    public event UnityAction<Sprite> EquipButtonPressed; 

    private void OnEnable()
    {
        _equipButton.onClick.AddListener(OnEquipButtonPressed);
    }

    private void OnDisable()
    {
        _equipButton.onClick.RemoveListener(OnEquipButtonPressed);
    }

    private void OnEquipButtonPressed()
    {
        EquipButtonPressed?.Invoke(_image.sprite);
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetEquipButtonInteractability(bool interactable)
    {
        _equipButton.interactable = interactable;
    }
}
