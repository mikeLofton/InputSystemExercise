using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehavior : MonoBehaviour
{
    private PlayerControls _playerControls;
    private PlayerMovementBehaviour _playerMovement;
    [SerializeField]
    private ProjectileSpawnerBehaviour _gun;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerMovement = GetComponent<PlayerMovementBehaviour>();
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
        _playerControls.Ship.Shoot.performed += (context) => _gun.Fire(); //started = On press/On hold /// performed = On release /// canceled = input didn't go through
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = _playerControls.Ship.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }
}
