using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFinishUI : MonoBehaviour
{
    public void GoToStart()
    {
        GameMaster.Instance._PlayerManager.DestroyAllPlayersInScene();
        GameMaster.Instance._SceneManager.ChangeSceneByIndex(0);
        GameMaster.Instance._UI.TurnOffWinLoseUI();
    }
}
