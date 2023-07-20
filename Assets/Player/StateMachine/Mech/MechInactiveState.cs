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
        if (_Player) FullWipe();
    }
    public override void CheckGround()
    {
    }

    private void FullWipe()
    {
        _Player._MechController._Mech._Movement.StopMovement();
        _Player = null;
    }
}
