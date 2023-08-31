using KinematicCharacterController;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro.EditorUtilities;
using UnityEngine;

public struct CharacterMovementInput
{
    public bool WantsToJump;
    public Vector2 Moveinput;
    public Quaternion LookRotation;
}


[RequireComponent(typeof(KinematicCharacterMotor))]
public class CharacterMovement : MonoBehaviour, ICharacterController
{
    public KinematicCharacterMotor Motor;
    [Header("Ground Movement")]
    public float maxSpeed;
    public float acceleration;
    public float rotationSpeed;
    public float Gravity = 30;
    public float JumpHeight = 1.5f;
    public float JumpRequestDuration = 0.1f; 
    private float jumpRequestExpireTime;

    [Header("Air Movement")]
    public float airMaxSpeed = 3;
    public float airAcceleration = 20;
    public float drag = 0.5f;

    public float JumpSpeed => Mathf.Sqrt(2 * Gravity * JumpHeight);

    [SerializeField] Vector3 moveInput;

    private void Awake()
    {
        Motor.CharacterController = this;
    }

    public void SetInput(in CharacterMovementInput input)
    {
        moveInput = Vector3.zero;
        if (input.Moveinput != Vector2.zero)
        {
            moveInput = new Vector3(input.Moveinput.x, 0, input.Moveinput.y).normalized;
            moveInput = input.LookRotation* moveInput* Time.deltaTime;
            moveInput.y = 0;
            moveInput.Normalize();
        }

        if (input.WantsToJump)
        {
            jumpRequestExpireTime = Time.time + JumpRequestDuration;
        }
    }


    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        if(moveInput != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(moveInput);
            currentRotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * deltaTime);
        }
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        if (Motor.GroundingStatus.IsStableOnGround)
        {
            var targetVelocity = moveInput * maxSpeed;

            if(Input.GetKey(KeyCode.LeftShift))
            {
                targetVelocity *= 1.5f;
            }
            currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.deltaTime);

            if (Time.time < jumpRequestExpireTime )
            {
                currentVelocity.y = JumpSpeed;
                jumpRequestExpireTime = 0;
                Motor.ForceUnground();
            }
        }

        else
        {
            var targetVelocityXZ = new Vector2 (moveInput.x , moveInput.z) * airMaxSpeed;
            var currentVelocityXZ = new Vector2(currentVelocity.x, currentVelocity.z);

            currentVelocityXZ = Vector2.MoveTowards(currentVelocityXZ, targetVelocityXZ, airAcceleration * deltaTime);

            currentVelocity.x = ApplyDrag(currentVelocityXZ.x, drag, deltaTime);
            currentVelocity.z = ApplyDrag(currentVelocityXZ.y, drag, deltaTime);
            
            currentVelocity.y -= Gravity* Time.deltaTime;
        }

    }

    private static float ApplyDrag(float v, float drag, float deltaTime)
    {
        return v * (1f / (1f + drag * deltaTime));
    }

    #region Not Implemented
    public void AfterCharacterUpdate(float deltaTime)
    {
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        
    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        return true;
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
    }

    public void PostGroundingUpdate(float deltaTime)
    {
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
    }
    #endregion
}
