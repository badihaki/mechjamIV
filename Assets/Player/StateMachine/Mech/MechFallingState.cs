using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechFallingState : PC_State
{
    public MechFallingState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    Vector2 moveInput;

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _Player._MechController._Mech._Movement.MoveCharacterHorizontal(moveInput.x);
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        moveInput = _Player._Controls._MoveInput;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_Player._MechController._Mech._Movement._CheckGrounded.IsGrounded()) _StateMachine.ChangeState(_Player._MechController._Mech._IdleState);
    }
}
