using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [Header("Referencias Componentes")]
    [SerializeField] Animator animator;

    [SerializeField] private float timeAttack;
    [SerializeField] private int countAttack;
    private void Attack()
    {
        timeAttack += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timeAttack >= 0.7f) //Verifica se clicamos no botão 0 do mouse e valida se já passamos pelo segundo 0.7f do time.
        {
            countAttack++;

            if (countAttack >3)
            {
                countAttack = 1;
            }

            //if (timeAttack >= animator.GetCurrentAnimatorStateInfo(0).length - 0.1f)
            //{
            //  countAttack = 1;
            //}
            animator.SetTrigger("Attack_0" + countAttack.ToString());
            timeAttack = 0;
            //if (timeAttack > animator.GetCurrentAnimatorStateInfo(0).length)
            //{

            //}
        }
    }

    public void ResetAttack()
    {
        countAttack = 0;
        Debug.Log("Attack");
    }

    private void Update()
    {
        Attack();
    }
}
