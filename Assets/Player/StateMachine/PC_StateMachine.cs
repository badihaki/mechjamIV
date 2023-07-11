using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_StateMachine
{
    [field: SerializeField] public PC_State currentState { get; private set; }

    public void InitializeStateMachine(PC_State state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void ChangeState(PC_State state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
