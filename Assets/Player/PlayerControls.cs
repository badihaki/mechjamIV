using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [field: SerializeField] public Vector2 _MoveInput { get; private set; }
    [field: SerializeField] public bool _JumpInput { get; private set; }
    [field: SerializeField] public bool _AttackInput { get; private set; }
    [field: SerializeField] public bool _DashInput { get; private set; }
    [field: SerializeField] public bool _InteractInput { get; private set; }

    public void OnMove(InputValue value) => ProcessMove(value.Get<Vector2>());
    private void ProcessMove(Vector2 input)
    {
        _MoveInput = input;
    }

    public void OnJump(InputValue value) => ProcessJump(value.isPressed);
    private void ProcessJump(bool input) => _JumpInput = input;
    public void UseJump() => _JumpInput = false;

    public void OnAttack(InputValue value) => ProcessAttack(value.isPressed);
    private void ProcessAttack(bool input) => _AttackInput = input;

    public void OnDash(InputValue value) => ProcessDash(value.isPressed);
    private void ProcessDash(bool input) => _DashInput = input;

    public void OnInteract(InputValue value) => ProcessInteract(value.isPressed);
    private void ProcessInteract(bool input) => _InteractInput = input;
    public void UseInteract() => _InteractInput = false;

    // end
}
