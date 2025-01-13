using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    [SerializeField] private GameObject carCamera, playerCamera;

    [SerializeField] private GameObject rccCamera;
    
    private void OnEnable()
    {
        Events.OnEnterCar += CarCameraActivate;
        Events.OnExitCar += PlayerCameraActivate;
    }

    private void CarCameraActivate()
    {
        carCamera.SetActive(true);
        playerCamera.SetActive(false);
    }

    private void PlayerCameraActivate()
    {
        carCamera.SetActive(false);
        playerCamera.SetActive(true);
        rccCamera.transform.SetParent(carCamera.transform);
    }
}
