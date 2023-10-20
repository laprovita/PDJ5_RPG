using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttack", menuName ="CreateAttack")]
public class Attack_Base_Scriptable : ScriptableObject
{
    public string attackName;
    public Sprite icon;
    public int damage;
    [SerializeField] public AnimatorOverrideController overrideController;

}
