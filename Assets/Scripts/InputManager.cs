using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerController;

    private PlayerController.MoveActions moveActions;
    private PlayerMotor playerMotor;
    private PlayerLook playerLook;

    private void Awake()
    {
        playerController = new PlayerController();
        moveActions = playerController.Move;

        playerMotor = GetComponent<PlayerMotor>();
        playerLook  = GetComponent<PlayerLook>();

        moveActions.Jump.performed += ctx => playerMotor.Jump();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        playerMotor.ProcessMove(moveActions.Walk.ReadValue<Vector2>());
        
    }

    private void LateUpdate()
    {
        playerLook.ProcessLook(moveActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        moveActions.Enable();
    }

    private void OnDisable()
    {
        moveActions.Disable();
    }
}
