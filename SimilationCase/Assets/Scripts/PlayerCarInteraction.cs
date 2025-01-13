using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCarInteraction : MonoBehaviour
{
    [SerializeField] private GameObject playerMesh;


    private GameObject currentCar;
    private bool isDriving = false;
    private PlayerInput _playerInput;
    private ThirdPersonController _thirdPersonController;
    private Rigidbody _rb;
    private CharacterController _characterController;


    private void Awake()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _playerInput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // "H" for Enter/Exit
        {
            if (isDriving)
            {
                ExitCar();
            }
            else if (currentCar != null)
            {
                EnterCar();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.CAR))
        {
            currentCar = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagManager.CAR))
        {
            currentCar = null;
        }
    }


    private void EnterCar()
    {
        if (currentCar == null) return;
        DeactivatePlayerPhysics();
        var carController = currentCar.GetComponent<CarController>();
        isDriving = true;
        carController.RccCarController.enabled = true;
        Events.OnEnterCar?.Invoke();
        transform.SetParent(currentCar.transform); // Attach player to car
        transform.position = carController.CarSitPos.position;
    }

    private void ExitCar()
    {
        if (currentCar == null) return;

        var carController = currentCar.GetComponent<CarController>();
        carController.RccCarController.enabled = false;
        isDriving = false;
        Events.OnExitCar?.Invoke();
        transform.SetParent(null); // Detach player from car
        transform.position = carController.CarOutPos.position; // Move player to exit point 
        currentCar = null;
        ActivatePlayerPhysics();
    }


    private void DeactivatePlayerPhysics()
    {
        _playerInput.enabled = false;
        _thirdPersonController.enabled = false;
        _rb.isKinematic = true;
        playerMesh.SetActive(false);
        _characterController.enabled = false;
    }

    private void ActivatePlayerPhysics()
    {
        _playerInput.enabled = true;
        playerMesh.SetActive(true);
        _thirdPersonController.enabled = true;
        _rb.isKinematic = false;
        _characterController.enabled = true;
    }
}