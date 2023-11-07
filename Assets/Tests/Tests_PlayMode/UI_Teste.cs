using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI_Teste: InputTestFixture
{
    Mouse mouse;
    int currentTest = 0;

    public override void Setup()
    {
        base.Setup();
        SceneManager.LoadScene(0);
        mouse = InputSystem.AddDevice<Mouse>();
    }

    [UnityTest]
    public IEnumerator StartGame_Test()
    {
        GameObject playButton = GameObject.FindGameObjectWithTag("PlayButton");
        string sceneName = SceneManager.GetActiveScene().name;
        Assert.That(sceneName, Is.EqualTo("Scene_Menu"));

        Click(playButton);
        yield return new WaitForSeconds(2F);

        sceneName = SceneManager.GetActiveScene().name;
        Assert.That(sceneName, Is.EqualTo("Scene_Menu"));
    }
    public void Click(GameObject uiElement)
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 screenPos = camera.WorldToScreenPoint(uiElement.transform.position);
        Set(mouse.position, screenPos);
        Click(mouse.leftButton);
        currentTest = 1;
    }
}
