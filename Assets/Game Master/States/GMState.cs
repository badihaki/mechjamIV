using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMState
{
    public float stateStartTime { get; protected set; }

    public virtual void Enter()
    {
        stateStartTime = Time.time;
    }
    public virtual void Exit()
    {

    }
    public virtual void GameLogic()
    {

    }

    //
}
