using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot_DeadState : PC_State
{
    public Pilot_DeadState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    bool isRespawning = false;
    public override void Enter()
    {
        base.Enter();

        isRespawning = false;
        Object.Instantiate(_Player._Effects._VisFX[0], _Player._PilotCharacter.transform);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= _StateStartTime + 0.35f && isRespawning == false)
        {
            _Player._PilotCharacter.gameObject.AddComponent<Destroyer>();
            _Player.Respawn();
            _Player = null;
            isRespawning = true;
        }
    }
}
