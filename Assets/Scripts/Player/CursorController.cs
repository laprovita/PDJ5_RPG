using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public void ActiveCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible= true;
    }

    public void DesactiveCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ChangeStateCursor()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.visible = !Cursor.visible;

            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void LateUpdate()
    {
        ChangeStateCursor();
    }

    private void Start()
    {
        DesactiveCursor();
    }
}
