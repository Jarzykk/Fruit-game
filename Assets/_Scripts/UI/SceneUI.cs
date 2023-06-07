using System;
using UnityEngine;
using UnityEngine.Events;

public class SceneUI : MonoBehaviour
{
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private Timer _timer;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private UIScreen _currentOpenScreen;

    public ImportantSceneObjects ImportantSceneObjects => _importantSceneObjects;
    
    public event UnityAction LoadNextSceneButtonPressed;

    private void OnEnable()
    {
        _timer.TimerStopped += EnableWinScreen;
        _winScreen.ShopButtonPressed += EnableShopScreen;
    }

    private void OnDisable()
    {
        _timer.TimerStopped -= EnableWinScreen;
        _winScreen.ShopButtonPressed -= EnableShopScreen;
    }

    private void EnableWinScreen()
    {
        DisableCurrentScreen();
        
        _currentOpenScreen = _winScreen;
        _winScreen.gameObject.SetActive(true);
    }

    private void EnableShopScreen()
    {
        DisableCurrentScreen();
        
        _currentOpenScreen = _shopScreen;
        _shopScreen.gameObject.SetActive(true);
    }

    private void DisableCurrentScreen()
    {
        if(_currentOpenScreen != null)
            _currentOpenScreen.gameObject.SetActive(false);
    }

    private void OnLoadNextLevelButtonPressed()
    {
        LoadNextSceneButtonPressed?.Invoke();
    }
}
