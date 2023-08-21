using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Player : MonoBehaviour
{
    [Header("Referencia dos componentes")]
    [SerializeField] Transform pivotPosition;
    [SerializeField] GameObject panel_PressF;

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
                    InvokeMethodOnScript(hit.transform.GetComponent<RefScript>().script,"Open");
                }
            }
        }
    }

    public void InvokeMethodOnScript(MonoBehaviour targetScript, string methodName)
    {
        var scriptType = targetScript.GetType();
        var method = scriptType.GetMethod(methodName);

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
