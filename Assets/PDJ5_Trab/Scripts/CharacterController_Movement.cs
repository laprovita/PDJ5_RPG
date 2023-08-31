using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_Movement : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float gravityAcceleration = -2f;
    [SerializeField] float speedMovement;
    [SerializeField] CharacterController cc;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), gravityAcceleration, Input.GetAxis("Vertical"));

        cc.Move(direction * speedMovement * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
}
