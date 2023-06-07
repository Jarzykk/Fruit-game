using UnityEngine;

public class ImportantSceneObjects : MonoBehaviour
{
    [SerializeField] private SwipeControlls _swipeControlls;
    [SerializeField] private PlayersBusket _playersBusket;

    public SwipeControlls SwipeControlls => _swipeControlls;
    public PlayersBusket PlayersBusket => _playersBusket;
}
