using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CameraController cameraController;
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var wantsToJump = Input.GetKeyDown(KeyCode.Space);

        characterMovement.SetInput(new CharacterMovementInput()
        {
            Moveinput = new Vector2(h, v),
            LookRotation = cameraController.lookRotation,
            WantsToJump = wantsToJump
        });;

        var lookX = -Input.GetAxis("Mouse Y");
        var lookY = Input.GetAxis("Mouse X");

        cameraController.IncrementLookRotation(new Vector2(lookX, lookY));
    }
}
