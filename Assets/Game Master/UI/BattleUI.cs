using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleUI : MonoBehaviour
{
    [Serializable]
    public struct _Player
    {
        public int id;
        public int lives;

        public int dashesLeft;
        public bool dashCooldown;
    }
    [field: SerializeField] public List<_Player> _Players { get; protected set; }

    public void Initialize()
    {
        _Players = new List<_Player>();
    }

    public void AddPlayers(Player[] players)
    {
        foreach(Player player in players)
        {
            _Player newPlayerStruct = new _Player();
            newPlayerStruct.id = player.GetComponent<PlayerInput>().playerIndex;

            newPlayerStruct.lives = player._Health._Lives;
            newPlayerStruct.dashesLeft = player._Movement.dashCount;
            newPlayerStruct.dashCooldown = true;

            _Players.Add(newPlayerStruct);
        }
    }
}
