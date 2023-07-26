using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechHitState : PC_State
{
    public MechHitState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (Time.time > _StateStartTime + 0.575f)
        {
            _StateMachine.ChangeState(_Player._MechController._Mech._IdleState);
        }
    }

    // end of the line
}
