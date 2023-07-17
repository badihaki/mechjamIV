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
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private bool testMode;

    public GMStateMachine _StateMachine { get; private set; }
    public StartGame _StartState { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;

        PlayerManager = GetComponent<GM_PlayerManager>();
        _UI = GetComponent<UI_Controller>();
        _UI.Initialize();

        _MatchSettings = GetComponent<MatchSettings>();

        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.DisableJoining();

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        BuildStateMachine();
    }

    private void BuildStateMachine()
    {
        _StateMachine = new GMStateMachine();
        _StartState = new StartGame();

        _StateMachine.InitializeStateMachine(_StartState);
    }

    private void Update()
    {
        if (testMode) StartTestMode();
    }

    private void StartTestMode()
    {
        _UI.TurnOnBattleUI();
        playerInputManager.EnableJoining();
        playerInputManager.JoinPlayer();
        testMode = false;
    }

    // end
}
