using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private RectTransform[] _PlayerCanvases; // { get; private set; }

    public void Initialize()
    {
        foreach (RectTransform canvas in _PlayerCanvases)
        {
            canvas.gameObject.SetActive(false);
        }
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

        RectTransform playerCanvas = _PlayerCanvases[player.playerIndex];
        playerCanvas.gameObject.SetActive(true);

        // set life
        ChangeLife(player.playerIndex, GameMaster.Instance._MatchSettings.playerLives);

        // set dash
        SetDash(player.playerIndex, player._Movement._CanDash);
    }

    public void ChangeLife(int playerIndex, int lifeTotal)
    {
        _PlayerCanvases[playerIndex].Find("Lives").Find("Amount").GetComponent<TextMeshProUGUI>().text = lifeTotal.ToString();
    }

    public void SetDash(int playerIndex, bool isActive)
    {
        print("setting dash to " + isActive.ToString());
        _PlayerCanvases[playerIndex].Find("Dash").GetComponent<Animator>().SetBool("active", isActive);
    }


    // end
}
