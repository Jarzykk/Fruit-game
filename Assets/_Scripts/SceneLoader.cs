using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private int[] _indexesOfScenesToLoad;

    private void OnEnable()
    {
        _importantSceneObjects.SceneUI.LoadNextSceneButtonPressed += LoadNextScene;
    }

    private void OnDisable()
    {
        _importantSceneObjects.SceneUI.LoadNextSceneButtonPressed -= LoadNextScene;
    }

    private void LoadNextScene()
    {
        int randomIndex = Random.Range(0, _indexesOfScenesToLoad.Length);

        if (SceneManager.GetActiveScene().name == SceneManager.GetSceneByBuildIndex(randomIndex).name)
        {
            randomIndex++;
            if (randomIndex > _indexesOfScenesToLoad.Length - 1)
                randomIndex = 0;
        }
        
        SceneManager.LoadScene(randomIndex);
    }
}
