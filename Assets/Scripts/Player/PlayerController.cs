using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var wantsToJump = Input.GetKeyDown(KeyCode.Space);

        characterMovement.SetInput(new CharacterMovementInput()
        {
            Moveinput = new Vector2(h, v),
            WantsToJump = wantsToJump
        });

        Debug.Log(message:$"{h},{v}");
    }
}
