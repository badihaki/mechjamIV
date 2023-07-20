using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechLightAttackState : PC_State
{
    public MechLightAttackState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }
    
    bool attackInput;

    public override void Enter()
    {
        base.Enter();

        _Player._MechController._Mech._Movement.StopMovement();
        _Player._MechController._Mech._Animator.SetBool(_AnimationName, true);
        _Player._Controls.UseAttack();
    }

    public override void CheckInputs()
    {
        base.CheckInputs();
        
        attackInput = _Player._Controls._AttackInput;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (Time.time > _StateStartTime + 0.15f && attackInput) _StateMachine.ChangeState(_Player._MechController._Mech._MediumAttackState);
        if (Time.time > _StateStartTime + 0.3f) _StateMachine.ChangeState(_Player._MechController._Mech._IdleState);
    }

    public override void Exit()
    {
        base.Exit();

        _Player._MechController._Mech._Animator.SetBool(_AnimationName, false);
    }
}
