using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect Instance;

    private CharacterSelectHelper helper;
    [field: SerializeField] public Transform[] templatePlacementPoints { get; private set; }

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

        helper.StartHelper();
    }

    public void AnotherPlayerIsReady()
    {
        numberOfReadyPlayers++;

        if (numberOfReadyPlayers == 2) StartCoroutine(AllPlayersAreReady());

    // end
    }

    private IEnumerator AllPlayersAreReady()
    {
        helper.StartingGame();
        yield return new WaitForSeconds(3.5f);
        GameMaster.Instance._StateMachine.ChangeState(GameMaster.Instance._WaitState);
        // print(GameMaster.Instance._SceneManager);
        GameMaster.Instance._SceneManager.ChangeSceneByIndex(3);
    }

    // end
}
