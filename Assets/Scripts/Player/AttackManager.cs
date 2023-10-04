using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [Header("Variaveis")]
    [SerializeField] private int indexCombo;
    [SerializeField] bool isAttacking;
    [SerializeField] float timeAttack;
    [SerializeField] int maxCountAttacks;

    [SerializeField] private float timeCurrent;
    float timePress;

    [Header("Componentes")]
    [SerializeField] Animator animator;

    private void Attack()
    {
        timeCurrent += Time.deltaTime;
        if(Input.GetMouseButtonUp(0))
        {
            if(timeCurrent > 0.75f)
            {
                indexCombo++;

            if(indexCombo > maxCountAttacks)
            {
                indexCombo = 0;
            }

            if(timeCurrent > 1.2f)
            {
                indexCombo = 1;
            }

            animator.SetTrigger("Attack_0" + indexCombo.ToString());

            timeCurrent = 0;
            }
            
        }

        else if(Input.GetMouseButton(0) && timeCurrent > 0.75f)
        {
            timePress += Time.deltaTime;

            if(timePress > 1f) //tempo pressionado
            {
                animator.SetTrigger("PressAttack_01");
                timePress = 0;
            }
        }

    }

    private void Update()
    {
        Attack();
    }
}
