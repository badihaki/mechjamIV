using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GMStartGameState : GMState
{
    public override void Enter()
    {
        base.Enter();

        StartMenu.Instance.Initialize();
    }
}
