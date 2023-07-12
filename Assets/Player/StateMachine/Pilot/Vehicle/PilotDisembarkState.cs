using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotDisembarkState : PC_State
{
    public PilotDisembarkState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _Player._MechController.DiscardMech();
        _Player._Movement._PhysicsController.bodyType = RigidbodyType2D.Dynamic;
        _Player._Movement.Eject();
        _Player._MechController._Mech.GetOutTheRobot();
    }

    public override void Exit()
    {
        base.Exit();

        _Player._PilotCharacter._Body.SetActive(true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (Time.time > _StateStartTime + 0.85f)
            _StateMachine.ChangeState(_Player._PilotCharacter._IdleState);
    }
}
