using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager_CameraPosition : MonoBehaviour
{
    public List<Transform> cameraPositions;
    public Transform cameraTransform;
    public Transform playerRef;

    private void Update()
    {
        ChangePosition();
    }

    private void ChangePosition()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraTransform.position = cameraPositions[0].position;
            cameraTransform.rotation = cameraPositions[0].rotation;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameraTransform.position = cameraPositions[1].position;
            cameraTransform.rotation = cameraPositions[1].rotation;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cameraTransform.position = cameraPositions[2].position;
            cameraTransform.rotation = cameraPositions[2].rotation;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cameraTransform.position = cameraPositions[3].position;
            cameraTransform.rotation = cameraPositions[3].rotation;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cameraTransform.position = playerRef.position;
            cameraTransform.rotation = playerRef.rotation;
        }
    }
}
