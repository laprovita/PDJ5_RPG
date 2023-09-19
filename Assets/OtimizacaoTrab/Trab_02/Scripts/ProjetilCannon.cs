using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilCannon : MonoBehaviour
{
    float time;
    private void Update()
    {
        transform.Translate(0, 0, 3 * Time.deltaTime);

        time+=1 * Time.deltaTime;

        if (time > 7)
        {
            Destroy(transform.gameObject);
        }
    }
}
