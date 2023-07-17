using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMStateMachine
{
    public GMState _CurrentState { get; private set; }

    public void InitializeStateMachine(GMState state)
    {
        _CurrentState = state;
        _CurrentState.Enter();
    }

    public void ChangeState(GMState state)
    {
        _CurrentState.Exit();
        _CurrentState = state;
        _CurrentState.Enter();
    }
}
