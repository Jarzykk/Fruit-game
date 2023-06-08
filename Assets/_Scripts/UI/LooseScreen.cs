using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LooseScreen : UIScreen
{
    [SerializeField] private Button _continueButton;

    public event UnityAction ContinueButtonPressed;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonPressed);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonPressed);
    }

    private void OnContinueButtonPressed()
    {
        ContinueButtonPressed?.Invoke();
    }
}
