using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    private void LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }

    private void UnloadAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(scene);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadYourAsyncScene("Scene_03");
        }

        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            UnloadAsyncScene("Scene_03");
        }
    }
}
