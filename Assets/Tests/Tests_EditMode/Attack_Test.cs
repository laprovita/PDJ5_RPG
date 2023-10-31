using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEditor.VersionControl;
using UnityEngine;

public class Attack_Test
{
    [Test]
    public void Attack_TestSimplePasses()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<ComboManager>();

        Assert.Greater(player.attackBase_Scriptable.Capacity, 1);
    }

    [Test]
    public void Attack_CheckComboDamage()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<ComboManager>();

        List<float> damage = new List<float>() {10,-20,5,5,10};
        List<float> buff = new List<float>() { -2, 1.5f, -1};

        Assert.AreEqual(30,player.GetDamageInCombo(damage, buff));
    }

    [Test]
    public void State_CheckPlayer()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<ComboManager>();
        bool controll = true;

        List<int> lifeList = new List<int>() { 91, 51, 16, 16 };
        List<int> stamineList = new List<int>() { 0, 0, 98, 0 };
        List<string> stateList = new List<string>() { "Normal", "Machucado", "Frenesi", "Morrendo" };

        Assert.AreEqual(stateList[0].ToString(), player.CheckState(lifeList[0], stamineList[0]));
        Assert.AreEqual(stateList[1].ToString(), player.CheckState(lifeList[1], stamineList[1]));
        Assert.AreEqual(stateList[2].ToString(), player.CheckState(lifeList[2], stamineList[2]));
        Assert.AreEqual(stateList[3].ToString(), player.CheckState(lifeList[3], stamineList[3]));
    }


}
