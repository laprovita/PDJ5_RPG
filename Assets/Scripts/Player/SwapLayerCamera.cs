using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapLayerCamera : MonoBehaviour
{
    [SerializeField] Camera camera;

    public void AttLayer()
    {
        camera.cullingMask = LayerMask.GetMask("Minimap");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AttLayer();
        }
    }
}
