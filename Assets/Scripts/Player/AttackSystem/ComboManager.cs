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
    [SerializeField] public List<Attack_Base_Scriptable> attackBase_Scriptable = new List<Attack_Base_Scriptable>(2);
    [SerializeField] private int currentAnimation;
    [SerializeField] private float time;

    public int maxLife = 100;
    public int maxStamina = 100;

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
                //weapon.ActiveAttack(attackBase_Scriptable[currentAnimation].damage, comboAnimator.GetCurrentAnimatorStateInfo(0).length - time);
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
            if (currentAnimation < attackBase_Scriptable.Count-1)
            {
                currentAnimation++;
                comboAnimator.runtimeAnimatorController = attackBase_Scriptable[currentAnimation].overrideController;
                comboAnimator.Play("Attack", 0, 0);
                time = 0;
                //weapon.ActiveAttack(attackBase_Scriptable[currentAnimation].damage, comboAnimator.GetCurrentAnimatorStateInfo(0).length - time);
                nextAttack = false;
            }

            else
            {
                currentAnimation = 0;
                comboAnimator.runtimeAnimatorController = attackBase_Scriptable[currentAnimation].overrideController;
                comboAnimator.Play("Attack", 0, 0);
                time = 0;
                //weapon.ActiveAttack(attackBase_Scriptable[currentAnimation].damage, comboAnimator.GetCurrentAnimatorStateInfo(0).length - time);
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

    public float GetDamageInCombo(List<float> damageList, List<float> buff)
    {
        float damage = 0;
        foreach(int value in damageList)
        {
            damage += value;
        }

        foreach(float value in buff)
        {
            damage *= value;
        }
        Debug.Log(damage);
        return damage;
    }

    public string CheckState(int life, int currentStamina)
    {
        if (life > maxLife * 0.9f)
        {
            return "Normal";
        }
        else if (life > maxLife * 0.5f)
        {
            return "Machucado";
        }
        else if (life > maxLife * 0.15f && currentStamina > maxStamina * 0.95f)
        {
            return "Frenesi";
        }
        else
        {
            return "Morrendo";
        }

    }

    void Update()
    {
        time += Time.deltaTime;
        Attack();
    }
}
