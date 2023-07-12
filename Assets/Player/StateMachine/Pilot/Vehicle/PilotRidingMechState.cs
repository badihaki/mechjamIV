using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotRidingMechState : PC_State
{
    public PilotRidingMechState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    protected bool interactInput;

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _Player._Mech.KeepPilotInMech();
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        interactInput = _Player._Controls._InteractInput;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (Time.time > _StateStartTime + 1.35f && interactInput)
            _StateMachine.ChangeState(_Player._PilotCharacter._DisembarkState);
    }
}
