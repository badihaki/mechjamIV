using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private RectTransform[] _PlayerCanvases;

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

    public void SetWeaponReady(int playerIndex, bool isWeaponReady = true)
    {
        if (isWeaponReady)
        {
            _PlayerCanvases[playerIndex].Find("Ammo").GetComponent<Image>().color = Color.black;
        }
        else
        {
            _PlayerCanvases[playerIndex].Find("Ammo").GetComponent<Image>().color = Color.red;
        }
    }

    public void ResetAmmo(int playerIndex, int maxAmmo) => _PlayerCanvases[playerIndex].GetComponentInChildren<AmmoCounter>().ResetAmmoCounter(maxAmmo);
    public void UseAmmo(int playerIndex) => _PlayerCanvases[playerIndex].GetComponentInChildren<AmmoCounter>().UseAmmo();


    // end
}
