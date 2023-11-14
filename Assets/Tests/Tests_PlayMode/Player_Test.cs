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

    [UnityTest]
    public IEnumerator TesteAtividade()
    {
        Weapon weapon = new Weapon();

        List<float> damage1 = new List<float> { 5,10,7,-10,8};
        List<float> buff1 = new List<float> { -2,1.5f,-1};

        Assert.AreEqual(60,GetAllDamageValue(damage1,buff1));
        return null;
    }

    public float GetAllDamageValue(List<float> damage, List<float> buff)
    {
        float returnDamage = 0;

        foreach (float value in damage)
        {
            returnDamage += value;
        }

        foreach(float value in buff)
        {
            returnDamage *= value;
        }

        return Mathf.Max(returnDamage,0);

        switch (returnDamage)
        {
            case > 90:

                break;
        }
    }
}
