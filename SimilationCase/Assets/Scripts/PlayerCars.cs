using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCars : MonoBehaviour
{

    [SerializeField] private List<Car> playerCars;


    private void SpwanMyCar(int i)
    {
        // RCC_CarControllerV3 spawnedVehicle = RCC.SpawnRCC(RCC_DemoVehicles.Instance.vehicles[i],
        //     spawnPosition.position, spawnPosition.rotation, false, false, false);
    }
    private void OnEnable()
    {
        Events.OnCarBuyed += CarBuyed;
    }

    private void OnDisable()
    {
        Events.OnCarBuyed -= CarBuyed;
    }

    private void CarBuyed(Car car)
    {
        playerCars.Add(car);
    }
    
    
}
