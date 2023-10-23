using NUnit.Framework;
using System.Collections.Generic;
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

        List<int> damage = new List<int>() {10,20,5,5,10};

        Assert.AreEqual(50,player.GetDamageInCombo(damage));
    }
}
