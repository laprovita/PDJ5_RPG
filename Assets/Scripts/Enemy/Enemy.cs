using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private EnemyObject enemyObject;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;

    [Header("Var Enemy")]
    [SerializeField] private int level; //use essa variavel para setar qual objeto 3D vamos ativar.
    [SerializeField] private int health;
    [SerializeField] private int attack;
    [SerializeField] private float speed;
    [SerializeField] private string type;
    [SerializeField] private AnimatorController animator;

    #region Private Methods
    private void Start()
    {
        SetScriptableEnemy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetScriptableEnemy();
        }
    }

    private void SetScriptableEnemy()
    {
        if (enemyObject != null)
        {
            level = enemyObject.level;
            health = enemyObject.health;
            attack = enemyObject.attack;
            speed = enemyObject.speed;
            type = enemyObject.type.ToString();
            animator = enemyObject.animatorController;
            meshFilter.mesh = enemyObject.mesh[Random.Range(0, enemyObject.mesh.Count)];
            meshRenderer.materials = enemyObject.materials;
        }

        else
        {
            //scriptable not set ;
        }
    }
    #endregion

    #region Public Methods
    public void SetEnemyObject(EnemyObject enemy)
    {
        enemyObject = enemy;
        SetScriptableEnemy();
    }


    #endregion
}
