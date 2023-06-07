using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialScreen : UIScreen
{
    [SerializeField] private Button _cancelButton;

    public event UnityAction CancelButtonPressed;

    private void OnEnable()
    {
        _cancelButton.onClick.AddListener(CancelButtonPressed);
    }

    private void OnDisable()
    {
        _cancelButton.onClick.RemoveListener(CancelButtonPressed);
    }

    private void OnCancelButtonPressed()
    {
        CancelButtonPressed?.Invoke();
    }
}
