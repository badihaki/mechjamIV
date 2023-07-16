using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GM_PlayerManager : MonoBehaviour
{
    [field:SerializeField] public List<Player> _PlayerList { get; private set; }
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
        GameMaster.Instance._UI._BattleUI.AddPlayer(player);
    }
}
