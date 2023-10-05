using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_NewInput : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] float speed;
    [SerializeField] float powerJump;

    [SerializeField] private Vector2 direction;

    public void Movimento(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
    }

    public void Pular(InputAction.CallbackContext value)
    {
        rigidbody.AddForce(Vector3.up * powerJump);
    }


    private void FixedUpdate()
    {
        rigidbody.AddForce(direction.x * speed, 0, direction.y * speed, ForceMode.Acceleration)  ;
    }
}
