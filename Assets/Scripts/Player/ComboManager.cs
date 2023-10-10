using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ComboManager : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Animator comboAnimator;
    //[SerializeField] private Weapon weapon;
    [SerializeField]private bool attacking;
    [SerializeField] private bool nextAttack;

    [Header("Variaveis")]
    [SerializeField] private List<Attack_Base_Scriptable> attackBase_Scriptable;
    [SerializeField] private int currentAnimation;
    [SerializeField] private float time;


    private void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!attacking)
            {
                time = 0;
                comboAnimator.runtimeAnimatorController = attackBase_Scriptable[currentAnimation].overrideController;
                comboAnimator.Play("Attack", 0, 0);
                attacking = true;
                Debug.Log("Foi apertado o botao do attack pela primeira vez");
            }
            else
            {
                NextAttackCheckCondition();
                Debug.Log("Foi apertado o botao do attack já com um combo inicializado");
            }

        }

        if (time > comboAnimator.GetCurrentAnimatorStateInfo(0).length + 1f && !nextAttack)
        {
            attacking = false;
            nextAttack = false;
            currentAnimation = 0;
        }
    }

    void NextAttack()
    {
        if(nextAttack)
        {
            if (currentAnimation <= attackBase_Scriptable.Count)
            {
                currentAnimation++;
                comboAnimator.runtimeAnimatorController = attackBase_Scriptable[currentAnimation].overrideController;
                comboAnimator.Play("Attack", 0, 0);
                time = 0;
                nextAttack = false;
            }

            else
            {
                currentAnimation = 0;
                comboAnimator.runtimeAnimatorController = attackBase_Scriptable[currentAnimation].overrideController;
                comboAnimator.Play("Attack", 0, 0);
                time = 0;
                nextAttack = false;
            }

        }
    }

    void NextAttackCheckCondition()
    {
        if (time > (comboAnimator.GetCurrentAnimatorStateInfo(0).length * 0.7f) && time <= comboAnimator.GetCurrentAnimatorStateInfo(0).length && !nextAttack)
        {
            Debug.Log("Next attack confirmado.");
            StartCoroutine(NextAttackSist());
        }
    }


    IEnumerator NextAttackSist()
    {

        Debug.Log("Esperando:" + (comboAnimator.GetCurrentAnimatorStateInfo(0).length - time) + " para o proximo attack");
        nextAttack = true;
        yield return new WaitForSeconds(comboAnimator.GetCurrentAnimatorStateInfo(0).length - time);

        NextAttack();

    }

    void Update()
    {
        time += Time.deltaTime;
        Attack();
    }

    void Start()
    {
        
    }
}
