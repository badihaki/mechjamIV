using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechIdleState : PC_State
{
    public MechIdleState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    protected Vector2 moveInput;

    public override void Enter()
    {
        base.Enter();

        _Player._MechController._Mech._Movement.StopMovement();
        Debug.Log("entering idle state");
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        moveInput = _Player._Controls._MoveInput;
        Debug.Log("move input: " + moveInput.x);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (moveInput.x != 0) _StateMachine.ChangeState(_Player._MechController._Mech._MoveState);
    }

    // end
}
