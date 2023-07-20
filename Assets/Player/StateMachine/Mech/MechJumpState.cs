using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechJumpState : PC_State
{
    public MechJumpState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, true);
        _Player._MechController._Mech._Movement.JumpCharacter();
        _Player._Controls.UseJump();
    }

    public override void Exit()
    {
        base.Exit();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, false);
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        if (_Player._Controls._JumpInput) _Player._Controls.UseJump();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_Player._MechController._Mech._Movement._CheckGrounded.IsGrounded()) _StateMachine.ChangeState(_Player._MechController._Mech._IdleState);
        if (Time.time > _StateStartTime + 0.135f) _StateMachine.ChangeState(_Player._MechController._Mech._FallingState);
    }

    // end
}
