using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private bool _isMoving = false;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _importantSceneObjects.SwipeControlls.SwipeStartedOnBasket += OnSwipeStarted;
        _importantSceneObjects.SwipeControlls.SwipeCanseled += OnSwipeCanceled;
    }

    private void OnDisable()
    {
        _importantSceneObjects.SwipeControlls.SwipeStartedOnBasket -= OnSwipeStarted;
        _importantSceneObjects.SwipeControlls.SwipeCanseled -= OnSwipeCanceled;
    }

    private void FixedUpdate()
    {
        if(_isMoving)
            Move();
        
        Debug.Log(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
    }

    private void OnSwipeStarted()
    {
        _isMoving = true;
    }

    private void OnSwipeCanceled()
    {
        _isMoving = false;
    }

    private void Move()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position += (new Vector3(mousePosition.x - transform.position.x, 0, 0)) * (_speed * Time.deltaTime);
    }
}
