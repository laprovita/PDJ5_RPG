using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    [Header("Referencia de componentes")]
    [SerializeField] GameObject canvasOverlay;
    public void Open()
    {
        canvasOverlay.SetActive(true);
        Debug.Log("Ola, eu sou o vendedor! Você quer ver meus produtos?");
    }
}
