using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_State
{
    public PC_State(Player player, PC_StateMachine stateMachine, string animationName)
    {
        _Player = player;
        _StateMachine = stateMachine;
        _AnimationName = animationName;
    }

    public Player _Player { get; protected set; }
    public PC_StateMachine _StateMachine { get; protected set; }
    public string _AnimationName { get; protected set; }

    public float _StateStartTime { get; protected set; }
    public bool _IsExitingState { get; protected set; }
    public bool grounded { get; protected set; }

    public virtual void Enter()
    {
        _StateStartTime = Time.time;
        _IsExitingState = false;
    }

    public virtual void Exit()
    {
        _IsExitingState = true;
    }

    public virtual void LogicUpdate()
    {
        if (!_IsExitingState)
        {
            CheckInputs();
            CheckTransitions();
        }
    }

    public virtual void PhysicsUpdate()
    {
        grounded = _Player._Movement._CheckGrounded.IsGrounded();
    }

    public virtual void CheckInputs()
    {
        //
    }

    public virtual void CheckTransitions()
    {
        //
    }

    // end
}
