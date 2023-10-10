using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPointInMiniMap : MonoBehaviour
{
    [SerializeField] Camera cameraMinimap;
    [SerializeField] GameObject pointer;
    RaycastHit hit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraMinimap.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                SetPointerPosition(hit.point);
            }
        }
    }

    private void SetPointerPosition(Vector3 position)
    {
        if (!pointer.activeSelf)
        {
            pointer.SetActive(true);
        }
        pointer.transform.position = position;

    }
}
