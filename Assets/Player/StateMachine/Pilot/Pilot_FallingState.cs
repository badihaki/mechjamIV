using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot_FallingState : PC_State
{
    public Pilot_FallingState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    protected Vector2 moveInput;
    protected bool attackInput;
    protected bool dashInput;

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _Player._Interact.DetectInteract();
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
        attackInput = _Player._Controls._AttackInput;
        dashInput = _Player._Controls._DashInput;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (grounded) _StateMachine.ChangeState(_Player._PilotCharacter._IdleState);
        if (_Player._Movement.dashTimer <= 0.0f && dashInput) _StateMachine.ChangeState(_Player._PilotCharacter._DashState);
    }

    // end
}
