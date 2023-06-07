using System.Collections;
using System.Collections.Generic;
using GG.Infrastructure.Utils.Swipe;
using UnityEngine.Events;
using UnityEngine;

public class SwipeControlls : MonoBehaviour
{
    [SerializeField] private SwipeListener _swipeListener;
    
    private Camera _mainCamera;
    
    private bool _controllsEnabled = true;

    private PlayersBusket _selectedPlayersBusket;

    public event UnityAction SwipeStartedOnBasket;
    public event UnityAction SwipeCanseled;

    private void OnEnable()
    {
        _swipeListener.OnSwipe.AddListener(OnSwipe);
        _swipeListener.OnSwipeCancelled.AddListener(OnSwipeCanseled);

        _mainCamera = Camera.main;
    }

    private void OnDisable()
    {
        _swipeListener.OnSwipe.RemoveListener(OnSwipe);
        _swipeListener.OnSwipeCancelled.RemoveListener(OnSwipeCanseled);
    }

    private void OnSwipe(string swipeDirection)
    {
        if (_controllsEnabled == false)
            return;
        
        TrySetPlayerBusket(_swipeListener.SwipeStartPoint);

        if(_selectedPlayersBusket != null)
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
            if(hit.collider.TryGetComponent<PlayersBusket>(out PlayersBusket playersBusket))
            {
                _selectedPlayersBusket = playersBusket;
                SwipeStartedOnBasket?.Invoke();
                Debug.Log("Basket is chosen");
                break;
            }
        }
    }

    private void OnSwipeCanseled()
    {
        SwipeCanseled?.Invoke();
        Debug.Log("Basket realised");
        _selectedPlayersBusket = null;
    }

    private void DisableControlls()
    {
        _controllsEnabled = false;
    }
}
