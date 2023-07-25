using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotEmbarkState : PC_State
{
    public PilotEmbarkState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // _Player._Movement._PhysicsController.isKinematic = true;
        _Player._Movement.StopMovement();
        _Player._Movement._PhysicsController.bodyType = RigidbodyType2D.Kinematic;
        _Player._PilotCharacter._Body.SetActive(false);
        _Player._PilotCharacter.transform.Find("Hurtbox").gameObject.SetActive(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (Time.time > _StateStartTime + 0.85f) _StateMachine.ChangeState(_Player._PilotCharacter._RidingMechState);
    }
}
