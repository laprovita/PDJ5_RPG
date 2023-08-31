using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh_Movement : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform transformIndication;
    [SerializeField] Vector3 v3position;
    [SerializeField] bool goPosition;

    RaycastHit hit;

    private void Update()
    {
        Movemente();
    }

    private void Movemente()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                transformIndication.position= hit.point;
                agent.destination = transformIndication.position;
                
            }
        }

        if (goPosition)
        {
            agent.destination = v3position;
        }
    }
}
