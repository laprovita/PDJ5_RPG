using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyObject : ScriptableObject
{
    [Header("Enemy Attributes")]
    public int level;
    public int health;
    public int attack;
    public float speed;
    public enum Type { Melee, Range, Explosive, Flying }
    public Type type;
    public AnimatorController animatorController;
    public List<Mesh> mesh;
    public Material[] materials;


    #region Public Methods
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Death
        }
    }
    #endregion
}
