using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechHeavyAttackState : PC_State
{
    public MechHeavyAttackState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, true);
        _Player._Controls.UseAttack();
    }
    public override void Exit()
    {
        base.Exit();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, false);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (Time.time > _StateStartTime + 0.65f) _StateMachine.ChangeState(_Player._MechController._Mech._IdleState);
    }
}
