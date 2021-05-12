using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehaviour : MonoBehaviour
{
    private PlayerControls _playerControls;
    private PlayerMovementBehaviour _playerMovement;
    [SerializeField]
    private ProjectileSpawnerBehaviour _projectileSpawner;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovementBehaviour>();
        _playerControls.Ship.Shoot.performed += (context) => _projectileSpawner.Fire();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = _playerControls.Ship.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }
}
