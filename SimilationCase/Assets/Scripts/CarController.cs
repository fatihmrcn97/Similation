using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] private Transform carOutPos;
    [SerializeField] private RCC_CarControllerV3 rcc_carController;
    [SerializeField] private Transform carSitPos;
    
    public Transform CarOutPos => carOutPos;
    public Transform CarSitPos => carSitPos;
    public RCC_CarControllerV3 RccCarController => rcc_carController;
}
