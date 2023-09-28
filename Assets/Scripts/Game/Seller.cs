using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Seller : MonoBehaviour
{
    [Header("Referencia de componentes")]
    [SerializeField] GameObject canvasOverlay;
    [SerializeField] Transform my_TargetView;
    public void Open()
    {
        canvasOverlay.SetActive(true);
        Debug.Log("Ola, eu sou o vendedor! Você quer ver meus produtos?");
        GameObject refCamera = GameObject.FindGameObjectWithTag("MainCamera");
        CinemachineVirtualCamera refVirtualCamera = refCamera.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        refVirtualCamera.Follow = my_TargetView;
        refVirtualCamera.LookAt = this.transform;
    }

    public void ExitSeller()
    {
        GameObject refCamera = GameObject.FindGameObjectWithTag("MainCamera");
        refCamera.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>().Follow = null;
        refCamera.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>().LookAt = null;
    }
}
