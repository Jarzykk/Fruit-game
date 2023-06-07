using UnityEngine;
using UnityEngine.Serialization;

public class ImportantSceneObjects : MonoBehaviour
{
    [SerializeField] private SwipeControlls _swipeControlls;
    [SerializeField] private PlayersBasket playersBasket;
    [SerializeField] private Timer _timer;
    [SerializeField] private PlayersMoney _playersMoney;
    [SerializeField] private ShopManager _shopManager;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Inventory _inventory;

    public SwipeControlls SwipeControlls => _swipeControlls;
    public PlayersBasket PlayersBasket => playersBasket;
    public Timer Timer => _timer;
    public PlayersMoney PlayersMoney => _playersMoney;
    public ShopManager ShopManager => _shopManager;
    public PlayerData PlayerData => _playerData;
    public Inventory Inventory => _inventory;
}
