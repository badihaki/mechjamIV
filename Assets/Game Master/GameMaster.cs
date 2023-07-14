using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { get; private set; }
    public GM_PlayerManager PlayerManager { get; private set; }
    public UI_Controller _UI { get; private set; }
    public MatchSettings _MatchSettings { get; private set; }

    [SerializeField] private bool testMode;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;

        PlayerManager = GetComponent<GM_PlayerManager>();
        _UI = GetComponent<UI_Controller>();
        _UI.Initialize();

        _MatchSettings = GetComponent<MatchSettings>();

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // if (testMode) StartTestMode();
    }

    private void Update()
    {
        if (testMode) StartTestMode();
    }

    private void StartTestMode()
    {
        _UI.TurnOnBattleUI();
        GetComponent<PlayerInputManager>().JoinPlayer();
        testMode = false;
    }

    // end
}
