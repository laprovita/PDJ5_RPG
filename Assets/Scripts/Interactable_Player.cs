using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

interface Interactable{
    public void Interact();
}

struct StructInteractable
{
    public int valor;
}


public class Interactable_Player : MonoBehaviour
{
    [Header("Referencia dos componentes")]
    [SerializeField] Transform pivotPosition;
    [SerializeField] GameObject panel_PressF;
    [SerializeField] Inventory inventory;
    [Header("Variaveis de saida")]
    [SerializeField] RaycastHit hit;

void Update()
{
    ShootRaycast();
}


    #region Private Methods
    private void ShootRaycast()
    {
        if(panel_PressF.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            if(Physics.Raycast(pivotPosition.position, pivotPosition.forward,out hit, 2))
            {
                Debug.DrawRay(pivotPosition.position,pivotPosition.forward, Color.black, 3);
                if(hit.transform.CompareTag("Interactable"))
                {
                    if(hit.transform.TryGetComponent(out RefScript refScript))
                    {
                        InvokeMethodOnScript(refScript.script, "Open");
                    }
                    
                    else if (hit.transform.TryGetComponent(out Interactable interactable))
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }

    public void InvokeMethodOnScript(MonoBehaviour targetScript, string methodName)
    {
        Type scriptType = targetScript.GetType();
        MethodInfo method = scriptType.GetMethod(methodName);

        if (method != null)
        {
            method.Invoke(targetScript, null);
        }
        else
        {
            Debug.LogWarning($"Method '{methodName}' not found on script '{scriptType.Name}'.");
        }
    }
    #endregion

#region Collider Methods
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Interactable"))
        {
            panel_PressF.SetActive(true);
        }

        if (collider.CompareTag("ItemFloor"))
        {
            inventory.AddItem(collider.GetComponent<Item_InFloor>().item);
            Destroy(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Interactable"))
        {
            panel_PressF.SetActive(false);
        }
    }
    #endregion
}
