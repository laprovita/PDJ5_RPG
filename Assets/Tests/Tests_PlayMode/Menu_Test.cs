using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu_Test: InputTestFixture
{
    Mouse mouse;


    public override void Setup()
    {
        base.Setup(); //Garante que qualquer inicialização na clase pai seja realizada ante de execitar o código adicional (override /substitui).
        SceneManager.LoadScene(0);//Carrega no cena com index 0/ cena do Menu.
    }

    public void ClickUI(GameObject uiElement)
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 screenPos = camera.WorldToScreenPoint(uiElement.transform.position);
        Set(mouse.position, screenPos);
        Click(mouse.leftButton);
    }

    [UnityTest]
    public IEnumerator Menu_TestWithEnumeratorPasses()
    {
        GameObject buttonObject = GameObject.FindGameObjectWithTag("PlayButton"); //Procuro a tag "PlayButton".
        Assert.IsNotNull(buttonObject); //Rodo um teste para verificar se está "null" ou não.
        yield return null;
    }
}
