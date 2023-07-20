using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechIdleState : PC_State
{
    public MechIdleState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    protected Vector2 moveInput;
    bool jumpInput;
    bool attackInput;

    public override void Enter()
    {
        base.Enter();

        _Player._MechController._Mech._Movement.StopMovement();
        _Player._MechController._Mech._Animator.SetBool(_AnimationName, true);
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        moveInput = _Player._Controls._MoveInput;
        jumpInput = _Player._Controls._JumpInput;
        attackInput = _Player._Controls._AttackInput;
    }

    public override void CheckGround()
    {
        grounded = _Player._MechController._Mech._Movement._CheckGrounded.IsGrounded();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (moveInput.x != 0) _StateMachine.ChangeState(_Player._MechController._Mech._MoveState);
        if (jumpInput) _StateMachine.ChangeState(_Player._MechController._Mech._JumpState);
        if (attackInput) _StateMachine.ChangeState(_Player._MechController._Mech._LightAttackState);
        if (!_Player._MechController._Mech._Movement._CheckGrounded.IsGrounded()) _StateMachine.ChangeState(_Player._MechController._Mech._FallingState);
    }

    public override void Exit()
    {
        base.Exit();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, false);
    }

    // end
}
