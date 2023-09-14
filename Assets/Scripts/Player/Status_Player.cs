using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Player : MonoBehaviour
{
    [Header("Estatísticas Estamina")]
    public float stamina_Count;
    public float stamina_Max;
    public float stamina_Add;

    [Header("Estatísticas de Peso")]
    public float weight;

    [Header("Estatísticas Desviar")]
    public int dodge_Count;

    [Header("Referências")]
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
