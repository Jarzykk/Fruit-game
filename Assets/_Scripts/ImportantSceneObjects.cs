using UnityEngine;

public class ImportantSceneObjects : MonoBehaviour
{
    [SerializeField] private SwipeControlls _swipeControlls;
    [SerializeField] private PlayersBusket _playersBusket;
    [SerializeField] private Timer _timer;
    [SerializeField] private PlayersMoney _playersMoney;

    public SwipeControlls SwipeControlls => _swipeControlls;
    public PlayersBusket PlayersBusket => _playersBusket;
    public Timer Timer => _timer;
    public PlayersMoney PlayersMoney => _playersMoney;
}
