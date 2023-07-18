using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMBattleState : GMState
{
    public override void Enter()
    {
        base.Enter();

        GameMaster.Instance._UI.TurnOnBattleUI();
        GameMaster.Instance._PlayerManager.PopulateSpawnPointList();
        GameMaster.Instance._PlayerManager.BuildAllPlayersIntoScene();
    }
}
