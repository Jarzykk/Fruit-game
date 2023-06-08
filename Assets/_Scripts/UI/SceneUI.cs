using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour
{
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private ShopManager _shopScreen;
    [SerializeField] private TutorialScreen _tutorialScreen;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Timer _timer;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private Button _tutorialButton;
    [SerializeField] private Button _inventoryButton;

    private UIScreen _currentOpenScreen;

    public ImportantSceneObjects ImportantSceneObjects => _importantSceneObjects;
    
    public event UnityAction LoadNextSceneButtonPressed;
    public event UnityAction NotEndLevelScreenOpened;
    public event UnityAction NotEndlevelScreenClosed;

    private void OnEnable()
    {
        _timer.TimerStopped += EnableWinScreen;
        _winScreen.ShopButtonPressed += EnableShopScreen;
        _winScreen.NextSceneButtonPressed += OnLoadNextLevelButtonPressed;
        _shopScreen.LoadNextSceneButtonPressed += OnLoadNextLevelButtonPressed;
        _inventory.CancelScreenButtonPressed += DisableCurrentScreen;
        _tutorialScreen.CancelButtonPressed += DisableCurrentScreen;
        
        _tutorialButton.onClick.AddListener(EnableTutorialScreen);
        _inventoryButton.onClick.AddListener(EnableInventory);
    }

    private void OnDisable()
    {
        _timer.TimerStopped -= EnableWinScreen;
        _winScreen.ShopButtonPressed -= EnableShopScreen;
        _winScreen.NextSceneButtonPressed -= OnLoadNextLevelButtonPressed;
        _shopScreen.LoadNextSceneButtonPressed -= OnLoadNextLevelButtonPressed;
        _inventory.CancelScreenButtonPressed -= DisableCurrentScreen;
        _tutorialScreen.CancelButtonPressed -= DisableCurrentScreen;
        
        _tutorialButton.onClick.RemoveListener(EnableTutorialScreen);
        _inventoryButton.onClick.RemoveListener(EnableInventory);
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
        NotEndLevelScreenOpened?.Invoke();
    }

    private void EnableTutorialScreen()
    {
        DisableCurrentScreen();

        _currentOpenScreen = _tutorialScreen;
        _tutorialScreen.gameObject.SetActive(true);
        NotEndLevelScreenOpened?.Invoke();
    }

    private void DisableCurrentScreen()
    {
        if (_currentOpenScreen == null)
            return;
        
        _currentOpenScreen.gameObject.SetActive(false);
        NotEndlevelScreenClosed?.Invoke();
    }

    private void OnLoadNextLevelButtonPressed()
    {
        LoadNextSceneButtonPressed?.Invoke();
    }
}
