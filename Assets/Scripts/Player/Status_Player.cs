using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Player : MonoBehaviour
{
    [Header("Estat�sticas Estamina")]
    public float stamina_Count;
    public float stamina_Max;
    public float stamina_Add;

    [Header("Estat�sticas de Peso")]
    public float weight;

    [Header("Estat�sticas Desviar")]
    public int dodge_Count;

    [Header("Refer�ncias")]
    public Inventory refInventory;


    #region Public Methods
    #region Staminas
    public void AddStaminaCount()
    {

    }
    #endregion

    #region Weight
    public void WeightCalculate()
    {
        weight = 0;
        foreach (Item_Scriptable item in refInventory.allItens)
        {
            weight += item.Weight;
        }
    }
    #endregion


    #endregion
}
