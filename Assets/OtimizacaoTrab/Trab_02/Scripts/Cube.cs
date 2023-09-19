using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int life = 2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colidiu: " + other.name);
        if (other.gameObject.GetComponent<ProjetilCannon>()) 
        {
            Destroy(other.gameObject);
            life--;
        }

        else
        {
            gameObject.SetActive(false);
            life = 2;
        }
    }

    private void Update()
    {
        if(life <= 0)
        {
            gameObject.SetActive(false);
            life = 2;
        }
    }
}
