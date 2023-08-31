using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CameraController cameraController;

    [SerializeField] private Animator animator;

    float h;
    float v;
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            h = Input.GetAxis("Horizontal")*2;
            v = Input.GetAxis("Vertical")*2;
        }
        else
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        
        animator.SetFloat("Vertical", v);
        animator.SetFloat("Horizontal", h);

        var wantsToJump = Input.GetKeyDown(KeyCode.Space);
        if(wantsToJump)
        {
            animator.SetTrigger("Jump");
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("Dodge");
        }

        characterMovement.SetInput(new CharacterMovementInput()
        {
            Moveinput = new Vector2(h, v),
            LookRotation = cameraController.lookRotation,
            WantsToJump = wantsToJump

        });

        var lookX = -Input.GetAxis("Mouse Y");
        var lookY = Input.GetAxis("Mouse X");

        cameraController.IncrementLookRotation(new Vector2(lookX, lookY));
    }
}
