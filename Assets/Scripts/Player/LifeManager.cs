using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    //Evento
    public delegate void LifeChangedEnvetHandler(int currentLife);
    public event LifeChangedEnvetHandler OnLifeChanged;

    [SerializeField]private int MaxLife;
    [SerializeField]private int CurrentLife;

    public int CurrentLifeCheck
    {
        get{ return CurrentLife;}
    }

    public void AddLife(int value)
    {
        CurrentLife += value;

        if(CurrentLife > MaxLife)
        {
            CurrentLife = MaxLife;
        }

        OnLifeChanged?.Invoke(CurrentLife);
    }

    public void RemoveLife(int value)
    {
        CurrentLife -= value;

        if(CurrentLife <=0)
        {
            CurrentLife = 0;
            Die();
        }

        OnLifeChanged?.Invoke(CurrentLife);
    }

    public void Die()
    {
        Debug.Log("Objeto " + gameObject.name + " morreu.");
    }
}
