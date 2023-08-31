using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraController : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public Transform cameraTarget;
    public float targetHeight;
    public Vector2 XRotationRange = new Vector2(-70, 70);
    public Quaternion lookRotation => cameraTarget.rotation;

    private Vector2 targetLook;

    public void IncrementLookRotation(Vector2 lookDelta)
    {
        targetLook += lookDelta;
        targetLook.x = Mathf.Clamp(targetLook.x, XRotationRange.x, XRotationRange.y);
    }

    private void LateUpdate()
    {
        cameraTarget.position = characterMovement.transform.position + Vector3.up * targetHeight ;
        cameraTarget.rotation = Quaternion.Euler(targetLook.x, targetLook.y,0);
    }
}
