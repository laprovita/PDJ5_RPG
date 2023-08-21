using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootChest : MonoBehaviour
{
    public void Open()
    {
        Debug.Log("Parabéns, você encontrou um baú de pilhagem, e por isso ganhou: R$" + Random.Range(5,150) + " moedas.");


    }
}
