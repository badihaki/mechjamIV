using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GM_PlayerManager : MonoBehaviour
{
    public static GM_PlayerManager Instance { get; private set; }

    [field:SerializeField] public List<Player> _PlayerList { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;
    }

    public void OnPlayerJoined(PlayerInput player)
    {
        print("player joined" + player.playerIndex);

        _PlayerList.Add(player.GetComponent<Player>());
    }
}
