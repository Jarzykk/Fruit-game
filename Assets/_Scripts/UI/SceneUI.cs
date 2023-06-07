using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour
{
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private TutorialScreen _tutorialScreen;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Timer _timer;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private Button _tutorialButton;
    [SerializeField] private Button _inventoryButton;

    private UIScreen _currentOpenScreen;

    public ImportantSceneObjects ImportantSceneObjects => _importantSceneObjects;
    
    public event UnityAction LoadNextSceneButtonPressed;

    private void OnEnable()
    {
        _timer.TimerStopped += EnableWinScreen;
        _winScreen.ShopButtonPressed += EnableShopScreen;
        
        _tutorialButton.onClick.AddListener(EnableTutorialScreen);
        _inventoryButton.onClick.AddListener(EnableInventory);
        _tutorialScreen.CancelButtonPressed += DisableCurrentScreen;
    }

    private void OnDisable()
    {
        _timer.TimerStopped -= EnableWinScreen;
        _winScreen.ShopButtonPressed -= EnableShopScreen;
        
        _tutorialButton.onClick.RemoveListener(EnableTutorialScreen);
        _inventoryButton.onClick.RemoveListener(EnableInventory);
        _tutorialScreen.CancelButtonPressed -= DisableCurrentScreen;
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

    private void EnableInventory()
    {
        DisableCurrentScreen();

        _currentOpenScreen = _inventory;
        _inventory.gameObject.SetActive(true);
    }

    private void EnableTutorialScreen()
    {
        DisableCurrentScreen();

        _currentOpenScreen = _tutorialScreen;
        _tutorialScreen.gameObject.SetActive(true);
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
