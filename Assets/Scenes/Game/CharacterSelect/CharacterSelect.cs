using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect Instance;

    private CharacterSelectHelper helper;
    [field: SerializeField] public Transform[] templatePlacementPoints { get; private set; }
    [SerializeField] private GameObject startGameCanvas;

    [SerializeField] private int numberOfReadyPlayers;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        GameMaster.Instance._StateMachine.ChangeState(GameMaster.Instance._CharacterSelectState);
        helper = GetComponentInChildren<CharacterSelectHelper>();

        startGameCanvas.SetActive(false);

        helper.StartHelper();
    }

    public void AnotherPlayerIsReady()
    {
        numberOfReadyPlayers++;

        if (numberOfReadyPlayers == 2) AllPlayersAreReady();

    // end
    }

    private void AllPlayersAreReady()
    {
        helper.gameObject.SetActive(false);
        startGameCanvas.SetActive(true);
    }

    public void StartGame()
    {
        print("Start the game");
    }

    // end
}
