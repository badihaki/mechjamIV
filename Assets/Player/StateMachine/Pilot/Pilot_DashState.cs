using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot_DashState : PC_State
{
    public Pilot_DashState(Player player, PC_StateMachine stateMachine, string animationName) : base(player, stateMachine, animationName)
    {
    }

    protected Vector2 moveInput;
    private float originalGravity;
    private bool enableMovement;

    public override void Enter()
    {
        base.Enter();

        originalGravity = _Player._Movement._PhysicsController.gravityScale;
        _Player._Movement._PhysicsController.gravityScale = 0.0f;

        moveInput = _Player._Controls._MoveInput;
        enableMovement = false;

        _Player._Movement.Dash(moveInput);
        _Player._Effects.ActivateTrail();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _Player._Interact.DetectInteract();
        if (!enableMovement && Time.time > (_StateStartTime + 0.45f)) enableMovement = true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (enableMovement) _Player._Movement.MoveCharacterHorizontal(moveInput.x);
    }

    public override void CheckInputs()
    {
        base.CheckInputs();

        moveInput = _Player._Controls._MoveInput;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_Player._Movement._CheckGrounded.IsGrounded() && Time.time >= (_StateStartTime + 1.0f))
        {
            _StateMachine.ChangeState(_Player._PilotCharacter._IdleState);
        }
        if (Time.time > _StateStartTime + (_Player._PilotSO.dashTime - (_Player._PilotSO.dashTime * 0.308f)))
        {
            if (_Player._Movement._CheckGrounded.IsGrounded()) _StateMachine.ChangeState(_Player._PilotCharacter._IdleState);
            else _StateMachine.ChangeState(_Player._PilotCharacter._FallingState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        _Player._Movement._PhysicsController.gravityScale = originalGravity;
        _Player._Effects.DeactivateTrail();
        if (_Player._Movement._CheckGrounded.IsGrounded() == true) _Player._Movement.StopMovement();
    }

    // end
}
