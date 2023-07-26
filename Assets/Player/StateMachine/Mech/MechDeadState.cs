using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDeadState : PC_State
{
    public MechDeadState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    // end of the line
}
