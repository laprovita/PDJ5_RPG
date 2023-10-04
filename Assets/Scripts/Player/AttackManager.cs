using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [Header("Variaveis")]
    [SerializeField] private int indexCombo;
    [SerializeField] bool isAttacking;
    [SerializeField] bool isPressAttacking;
    [SerializeField] float timeAttack;
    [SerializeField] int maxCountAttacks;

    [SerializeField] private float timeCurrent;
    [SerializeField] float timePress;

    [Header("Componentes")]
    [SerializeField] Animator animator;

    private void BasicAttack()
    {   
        //if(Input.GetMouseButtonDown(0))
        //{
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
            
        //}
        //timeCurrent += Time.deltaTime;
    }

    private void SpecialAttack()
    {
        animator.SetTrigger("PressAttack_01");
    }

    private void Block()
    {
        if(Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Block",true);
            Debug.Log("block");
        }

        if(Input.GetMouseButtonUp(1))
        {
            animator.SetBool("Block",false);
        }
        
    }
    private void Update()
    {
        timeCurrent += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AttackCoroutine());
        }
    
        Block();

    }

    IEnumerator AttackCoroutine()
    {
        float timePressed = 0f;
        
         while (Input.GetMouseButton(0))
        {
            timePressed += Time.deltaTime;
            if(timePressed > 0.5f)
            {
                Debug.Log("Especial pronto." + timePressed);

            }
            yield return null;
        }

        if (timePressed >= 0.5f)
        {
            // Ataque pesado
            Debug.Log("Ataque pesado!");
            SpecialAttack();
        }
        else
        {
            // Ataque básico
            Debug.Log("Ataque básico!");
            BasicAttack();
        }
    }
}
