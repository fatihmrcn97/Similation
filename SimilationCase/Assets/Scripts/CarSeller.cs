using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSeller : MonoBehaviour
{
    
    public GameObject carDealerUI; // Satış arayüzü

    [SerializeField] private CarSelection carSelection;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYER))
        {
            carDealerUI.SetActive(true); // UI'yi aç
            carSelection.isCarSelectionOpen = true;
            carSelection.SpawnVehicle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYER))
        {
            carSelection.isCarSelectionOpen = false;
            carDealerUI.SetActive(false); // UI'yi kapat
            carSelection.DeactivateSpawnedVehicles();
        }
    }
   
}
