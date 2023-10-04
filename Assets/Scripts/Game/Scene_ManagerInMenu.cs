using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_ManagerInMenu : MonoBehaviour, Interactable
{
    private int loadScene_Index;


    public void Interact()
    {
        StartGameScene();
    }

    public int CurrentSceneIndex
    {
        get { return loadScene_Index; }
    }

    private void StartGameScene()
    {
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
