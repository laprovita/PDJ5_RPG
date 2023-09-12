using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    [SerializeField] Transform resetPosition;

    private void Update()
    {
        if (transform.position.y <= -15f)
        {
            transform.position = resetPosition.position;
        }
    }
}
