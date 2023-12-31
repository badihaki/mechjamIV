using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GM_PlayerManager : MonoBehaviour
{
    [field:SerializeField] public List<Player> _PlayerList { get; private set; }
    [field: SerializeField] public List<PilotTemplate> _PilotTemplates { get; private set; }
    [field: SerializeField] public List<PilotSpawnPoint> _PlayerSpawnPoints { get; private set; }

    private void Awake()
    {
        _PlayerList = new List<Player>();
        _PlayerSpawnPoints = new List<PilotSpawnPoint>();
        PopulateSpawnPointList();
    }

    public void PopulateSpawnPointList()
    {
        PilotSpawnPoint[] spawnPoints = FindObjectsByType<PilotSpawnPoint>(FindObjectsSortMode.None);
        foreach (var spawnPoint in spawnPoints)
        {
            _PlayerSpawnPoints.Add(spawnPoint);
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Player player = playerInput.GetComponent<Player>();
        _PlayerList.Add(player);
        player.InitializePlayer();
        if (GameMaster.Instance.testMode)
        {
            player.BuildInGamePlayerCharacter();
            GameMaster.Instance._UI._BattleUI.AddPlayer(player);
        }
        else player.BuildPilotSelector();
    }

    public void BuildAllPlayersIntoScene()
    {
        for (int playerIndex = 0; playerIndex < _PlayerList.Count; playerIndex++)
        {
            _PlayerList[playerIndex].BuildInGamePlayerCharacter();
            GameMaster.Instance._UI._BattleUI.AddPlayer(_PlayerList[playerIndex]);
        }
    }

    public void DestroyAllPlayersInScene()
    {
        for (int playerIndex = 0; playerIndex < _PlayerList.Count; playerIndex++)
        {
            //if (_PlayerList[playerIndex]._PilotCharacter!=null)
            Destroy(_PlayerList[playerIndex].gameObject);
        }
        _PlayerList.Clear();
        _PlayerSpawnPoints.Clear();
    }

    public void UnreadyAllPlayers()
    {
        for (int playerIndex = 0; playerIndex < _PlayerList.Count; playerIndex++)
        {
            //if (_PlayerList[playerIndex]._PilotCharacter!=null)
            _PlayerList[playerIndex].Unready();
        }
    }
}
