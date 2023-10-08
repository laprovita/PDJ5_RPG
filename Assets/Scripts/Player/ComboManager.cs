using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Animator comboAnimator;
    //[SerializeField] private Weapon weapon;
    [SerializeField]private bool attacking;

    [Header("Variaveis")]
    [SerializeField] private List<Attack_Base_Scriptable> attackBase_Scriptable;
    [SerializeField] private int currentAnimation;
    [SerializeField] private float time;


    private void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Foi apertado o botao do mouse");
            StartCoroutine(ComboSystem());
        }
    }

    void NextAttack()
    {
        if(attacking)
        {
            currentAnimation++;
            attacking = false;
        }
    }

    IEnumerator ComboSystem()
    {
        /*
        Seta a animação do ataque q vammos chamar.
        boleana de attacking = true;
        verifico a condição se o time > 70% da animação e menor que o tempo total dela.
        true > eu quero continuar no combo de ataques. Chamo de novo minha corrotina msm sem o click.
        false> não quero continuar meu combo, logo eu reseto tudo e volto para o padrão.
        //if(time > minTime && time < comboAnimator.tempoTotalDaAnimacao)
        //{
        // attacking = true;
        //}

         Primeiro click chama um método específico para o primeiro ataque.
        */
        Debug.Log("Startamos a corrotina");
        attacking = true;
        if(time > (comboAnimator.GetCurrentAnimatorStateInfo(0).length*0.7f)&& time <=comboAnimator.GetCurrentAnimatorStateInfo(0).length)
        {
            yield return new WaitForSeconds(comboAnimator.GetCurrentAnimatorStateInfo(0).length - time);
            //Esperar a animação de ataque terminar.
            StartCoroutine(ComboSystem());
        }
        else
        {
        //    attacking = false;
        //    currentAnimation = 0;
        }
    }

    void Update()
    {

        Attack();
        NextAttack();
       // //Debug.Log(comboAnimator.GetCurrentAnimatorStateInfo(0).length + ", " + comboAnimator.GetCurrentAnimatorStateInfo(0) + ", " +comboAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash);

        //if(attacking)
        //{

        //}
    }

    void Start()
    {
        
    }
}
