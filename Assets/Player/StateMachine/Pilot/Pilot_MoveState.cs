using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot_MoveState : PC_State
{
    public Pilot_MoveState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    protected Vector2 moveInput;
    protected bool jumpInput;
    protected bool attackInput;
    protected bool dashInput;

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // _Player._Attack.RotateWeapon(moveInput);
        _Player._Attack.AimWeapon(moveInput);
        if (attackInput) _Player._Attack.Attack();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _Player._Movement.MoveCharacterHorizontal(moveInput.x);
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        moveInput = _Player._Controls._MoveInput;
        jumpInput = _Player._Controls._JumpInput;
        attackInput = _Player._Controls._AttackInput;
        dashInput = _Player._Controls._DashInput;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (moveInput.x == 0) _StateMachine.ChangeState(_Player._PilotCharacter._IdleState);
        if (jumpInput) _StateMachine.ChangeState(_Player._PilotCharacter._JumpState);
        if (!grounded) _StateMachine.ChangeState(_Player._PilotCharacter._FallingState);
        if (_Player._Movement.dashTimer <= 0.0f && dashInput) _StateMachine.ChangeState(_Player._PilotCharacter._DashState);
    }

    // end
}
