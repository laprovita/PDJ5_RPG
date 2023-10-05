using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [Header("Variaveis")]
    [SerializeField] private int indexCombo;
    [SerializeField] float timeAttack;
    [SerializeField] List<Attack_Base_Scriptable> attacks_List;

    [SerializeField] bool firstAttack;

    [SerializeField] private float timeLastAttack;

    [Header("Componentes")]
    [SerializeField] Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackClick();
        }

        ExitAttack();
    }


    void AttackClick()
    {
        if (Time.time - timeLastAttack >= 0.5f && indexCombo < attacks_List.Count && firstAttack)
        {
            CancelInvoke("EndCombo");

            if (Time.time - timeLastAttack >= 0.2f)
            {
                animator.runtimeAnimatorController = attacks_List[indexCombo].overrideController;
                animator.Play("Attack",0,0);
                firstAttack = false;

                indexCombo++;
                timeLastAttack = Time.time;

                if (indexCombo > attacks_List.Count)
                {
                    indexCombo = 0;
                }
            }
        }
        else if (Time.time - timeLastAttack >= 0.5f && indexCombo < attacks_List.Count && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            CancelInvoke("EndCombo");

            if (Time.time - timeLastAttack >= 0.2f)
            {
                animator.runtimeAnimatorController = attacks_List[indexCombo].overrideController;
                animator.Play("Attack", 0, 0);

                indexCombo++;
                timeLastAttack = Time.time;

                if (indexCombo > attacks_List.Count)
                {
                    indexCombo = 0;
                }
            }
        }
    }

    void ExitAttack() //Método para finalizar o combo 
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) // A animação está a mais de 90% do tempo total dela? E a animação que estou interagindo possuí a tag "attack"?
        {
            Invoke("EndCombo", 1);
        }
    }

    void EndCombo()
    {
        indexCombo= 0;
        timeLastAttack = Time.time;
        firstAttack = true;
    }
}
