using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootChest_Interface : MonoBehaviour, Interactable
{
    public void Interact()
    {
        Debug.Log("Parabéns, você encontrou um baú de pilhagem, e por isso ganhou: R$" + Random.Range(5, 150) + " moedas.");
    }
}
