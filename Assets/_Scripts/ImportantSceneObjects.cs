using UnityEngine;
using UnityEngine.Serialization;

public class ImportantSceneObjects : MonoBehaviour
{
    [Header("Controlls")]
    [SerializeField] private SwipeControlls _swipeControlls;
    
    [Header("UI")]
    [SerializeField] private Timer _timer;
    [SerializeField] private SceneUI _sceneUI;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private ShopManager _shopManager;
    
    [Header("Player")]
    [SerializeField] private PlayersBasket playersBasket;
    [SerializeField] private PlayersMoney _playersMoney;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Health _health;

    public SwipeControlls SwipeControlls => _swipeControlls;
    
    public Timer Timer => _timer;
    public SceneUI SceneUI => _sceneUI;
    public Inventory Inventory => _inventory;
    public ShopManager ShopManager => _shopManager;
    
    public PlayersBasket PlayersBasket => playersBasket;
    public PlayersMoney PlayersMoney => _playersMoney;
    public PlayerData PlayerData => _playerData;
    public Health Health => _health;
}
