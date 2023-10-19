using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerActionsManager : MonoBehaviour
{
    private PlayerActions actions;
    private PlayerActions.OnFootActions onFoot;
    private PlayerMovement movement;
    private PlayerLook look;
    private void Awake()
    {
        actions = new PlayerActions();
        onFoot = actions.OnFoot;

        movement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => movement.Jump();
    }

    private void Update()
    {

        movement.ProcessMovement(onFoot.Movement.ReadValue<Vector2>());
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
