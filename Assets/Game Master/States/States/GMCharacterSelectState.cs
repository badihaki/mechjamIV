using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMCharacterSelectState : GMState
{
    public override void Enter()
    {
        base.Enter();

        GameMaster.Instance.AllowJoinFromCharacterSelect();
    }

    public override void Exit()
    {
        base.Exit();

        for (int playerSearchIndex = 0; playerSearchIndex < GameMaster.Instance._PlayerManager._PlayerList.Count; playerSearchIndex++)
        {
            GameMaster.Instance._PlayerManager._PlayerList[playerSearchIndex].DestroyPilotSelector();
        }
    }
}
