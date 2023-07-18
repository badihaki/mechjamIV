using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMCharacterSelectState : GMState
{
    public override void Enter()
    {
        base.Enter();

        GameMaster.Instance.EnablePlayerJoining(true);
    }
}
