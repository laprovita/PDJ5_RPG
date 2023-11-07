using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Player_Test: InputTestFixture
{
    Mouse mouse;
    Keyboard keyboard;
    public override void Setup()
    {
        base.Setup();
        SceneManager.LoadScene(1);
        mouse = InputSystem.AddDevice<Mouse>();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }


    [UnityTest]
    public IEnumerator Player_TestWithEnumeratorPasses()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Assert.That(sceneName, Is.EqualTo("Scene_Teste"));
        yield return null;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Assert.NotNull(player);
        yield return null;
        player.gameObject.name = sceneName;
        Assert.AreEqual(sceneName, player.name);
        yield return null;
        Click(mouse.leftButton);
        Assert.AreEqual("Attack", player.GetComponent<Weapon>().ReturnAttack());
    }
}
