using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] float speedRotation;
    void Update()
    {
        RotationCamera();
    }

    private void RotationCamera()
    {
        float y = Input.GetAxis("Mouse X");
        cameraTransform.Rotate(0, y * speedRotation * Time.deltaTime, 0);
    }
}
