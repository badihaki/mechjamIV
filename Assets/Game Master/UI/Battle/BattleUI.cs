using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleUI : MonoBehaviour
{
    [Serializable]
    public struct _PlayerStruct
    {
        public int id;
        public TextMeshProUGUI lifeText;
        public Animator dashImage;
    }
    [field: SerializeField] public List<_PlayerStruct> _PlayersList { get; protected set; }
    [SerializeField] private RectTransform[] _PlayerCanvases; // { get; private set; }

    public void Initialize()
    {
        _PlayersList = new List<_PlayerStruct>();
    }

    public void AddPlayers(Player[] players)
    {
        foreach(Player player in players)
        {
            AddPlayer(player);
        }
    }

    public void AddPlayer(Player player)
    {
        _PlayerStruct newPlayerStruct = new _PlayerStruct();
        newPlayerStruct.id = player.GetComponent<PlayerInput>().playerIndex;

        RectTransform playerCanvas = _PlayerCanvases[newPlayerStruct.id];

        // set life
        newPlayerStruct.lifeText = playerCanvas.Find("Lives").Find("Amount").GetComponent<TextMeshProUGUI>();
        newPlayerStruct.lifeText.text = player._Health._Lives.ToString();

        // set dash
        newPlayerStruct.dashImage = playerCanvas.Find("Dash").GetComponent<Animator>();
        newPlayerStruct.dashImage.SetBool("active", true);

        _PlayersList.Add(newPlayerStruct);
    }

    public void ChangeLife(int playerIndex, int lifeTotal)
    {
        print("Pilot playerindex on hit: " + playerIndex);
        _PlayerStruct player = _PlayersList[FindPlayerInList(playerIndex)];
        player.lifeText.text = lifeTotal.ToString();

        for(int searchIndex = 0;searchIndex < _PlayersList.Count; searchIndex++)
        {
            if (_PlayersList[searchIndex].id == player.id)
            {
                _PlayersList[searchIndex] = player;
                break;
            }
        }
    }

    private int FindPlayerInList(int playerIndex)
    {
        int foundPlayer = 0;

        for (int searchIndex = 0; searchIndex < _PlayersList.Count; searchIndex++)
        {
            print("looking at ID: " + _PlayersList[searchIndex].id + " || searching for ID: " + playerIndex);
            if (_PlayersList[searchIndex].id == playerIndex)
            {
                foundPlayer = searchIndex;
                print("searched for: " + foundPlayer + " and found player with matching ID");
                break;
            }
            print("not index of " + searchIndex);
        }
        return foundPlayer;
    }

    // end
}
