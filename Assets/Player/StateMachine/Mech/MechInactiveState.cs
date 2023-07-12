using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechInactiveState : PC_State
{
    public MechInactiveState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    public override void Enter()
    {
        _Player._MechController._Mech._Movement.StopMovement();
        if (_Player) FullWipe();
    }

    private void FullWipe()
    {
        _Player = null;
    }
}
