using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopper : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private void OnEnable()
    {
        _importantSceneObjects.SceneUI.NotEndLevelScreenOpened += StopTime;
        _importantSceneObjects.SceneUI.NotEndlevelScreenClosed += UnstopTime;
    }

    private void OnDisable()
    {
        _importantSceneObjects.SceneUI.NotEndLevelScreenOpened -= StopTime;
        _importantSceneObjects.SceneUI.NotEndlevelScreenClosed -= UnstopTime;
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void UnstopTime()
    {
        Time.timeScale = 1;
    }
}
