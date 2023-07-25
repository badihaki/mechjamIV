using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMediumAttackState : PC_State
{
    public MechMediumAttackState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    bool attackInput;

    public override void Enter()
    {
        base.Enter();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, true);
        _Player._Controls.UseAttack();
        _Player._MechController._Mech.SetDamage(1, 4.85f);
    }
    public override void Exit()
    {
        base.Exit();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, false);
        _Player._MechController._Mech.ResetDamage();
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        attackInput = _Player._Controls._AttackInput;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (Time.time > _StateStartTime + 0.2f && attackInput) _StateMachine.ChangeState(_Player._MechController._Mech._HeavyAttackState);
        if (Time.time > _StateStartTime + 0.42f) _StateMachine.ChangeState(_Player._MechController._Mech._IdleState);
    }
}
