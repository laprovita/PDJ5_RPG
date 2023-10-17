using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttack", menuName ="CreateAttack")]
public class Attack_Base_Scriptable : ScriptableObject
{
    [SerializeField] public AnimatorOverrideController overrideController;
    public int damage;  
}
