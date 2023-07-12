using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMoveState : PC_State
{
    public MechMoveState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    Vector2 moveInput;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("enter mech move state");
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        moveInput = _Player._Controls._MoveInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _Player._MechController._Mech._Movement.MoveCharacterHorizontal(moveInput.x);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (moveInput.x == 0) _StateMachine.ChangeState(_Player._MechController._Mech._IdleState);
    }

    // end
}
