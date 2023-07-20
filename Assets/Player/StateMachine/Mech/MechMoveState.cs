using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMoveState : PC_State
{
    public MechMoveState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    Vector2 moveInput;
    bool jumpInput;

    public override void Enter()
    {
        base.Enter();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, true);
    }

    public override void Exit()
    {
        base.Exit();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, false);
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        moveInput = _Player._Controls._MoveInput;
        jumpInput = _Player._Controls._JumpInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _Player._MechController._Mech._Movement.MoveCharacterHorizontal(moveInput.x);
    }

    public override void CheckGround()
    {
        grounded = _Player._MechController._Mech._Movement._CheckGrounded.IsGrounded();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (moveInput.x == 0) _StateMachine.ChangeState(_Player._MechController._Mech._IdleState);
        if (jumpInput) _StateMachine.ChangeState(_Player._MechController._Mech._JumpState);
        if (!_Player._MechController._Mech._Movement._CheckGrounded.IsGrounded()) _StateMachine.ChangeState(_Player._MechController._Mech._FallingState);
    }

    // end
}
