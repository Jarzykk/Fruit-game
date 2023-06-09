using System.Collections;
using System.Collections.Generic;
using GG.Infrastructure.Utils.Swipe;
using UnityEngine.Events;
using UnityEngine;

public class SwipeControlls : MonoBehaviour
{
    [SerializeField] private SwipeListener _swipeListener;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    
    private Camera _mainCamera;
    
    private bool _controllsEnabled = true;

    private PlayersBasket _selectedPlayersBasket;

    public event UnityAction SwipeStartedOnBasket;
    public event UnityAction SwipeCanseled;

    private void OnEnable()
    {
        _swipeListener.OnSwipe.AddListener(OnSwipe);
        _swipeListener.OnSwipeCancelled.AddListener(OnSwipeCanseled);

        _importantSceneObjects.Timer.TimerStopped += DisableControlls;

        _mainCamera = Camera.main;
    }

    private void OnDisable()
    {
        _swipeListener.OnSwipe.RemoveListener(OnSwipe);
        _swipeListener.OnSwipeCancelled.RemoveListener(OnSwipeCanseled);
        
        _importantSceneObjects.Timer.TimerStopped += DisableControlls;
        
    }

    private void OnSwipe(string swipeDirection)
    {
        if (_controllsEnabled == false)
            return;
        
        TrySetPlayerBusket(_swipeListener.SwipeStartPoint);

        if(_selectedPlayersBasket != null)
        {
            switch (swipeDirection)
            {
                case "Right":
                    //
                    break;
                case "Left":
                    //
                    break;
            }
        }
    }

    private void TrySetPlayerBusket(Vector3 swipeStartPoint)
    {
        Vector3 swipeStartVector = _mainCamera.ScreenToWorldPoint(swipeStartPoint);
        RaycastHit2D[] hitInfo = Physics2D.RaycastAll(swipeStartVector, Vector2.zero);

        foreach (var hit in hitInfo)
        {
            if(hit.collider.TryGetComponent<PlayersBasket>(out PlayersBasket playersBusket))
            {
                _selectedPlayersBasket = playersBusket;
                SwipeStartedOnBasket?.Invoke();
                break;
            }
        }
    }

    private void OnSwipeCanseled()
    {
        SwipeCanseled?.Invoke();
        _selectedPlayersBasket = null;
    }

    private void DisableControlls()
    {
        _controllsEnabled = false;
        SwipeCanseled?.Invoke();
    }
}
