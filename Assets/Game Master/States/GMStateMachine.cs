using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMStateMachine
{
    public GMState _CurrentState { get; private set; }
    public bool ready { get; private set; } = false;

    public void InitializeStateMachine(GMState state)
    {
        _CurrentState = state;
        _CurrentState.Enter();
        ready = false;
    }

    public void ChangeState(GMState state)
    {
        _CurrentState.Exit();
        _CurrentState = state;
        _CurrentState.Enter();
    }
}
