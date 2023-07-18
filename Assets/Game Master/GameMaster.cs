using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { get; private set; }
    public GM_PlayerManager _PlayerManager { get; private set; }
    public UI_Controller _UI { get; private set; }
    public MatchSettings _MatchSettings { get; private set; }
    public GM_SceneManager _SceneManager { get; private set; }
    [SerializeField] private PlayerInputManager playerInputManager;
    [field: SerializeField] public bool testMode { get; private set; }

    // state machine
    public GMStateMachine _StateMachine { get; private set; }
    public GMWaitState _WaitState { get; private set; }
    public GMStartGameState _StartState { get; private set; }
    public GMCharacterSelectState _CharacterSelectState { get; private set; }
    public GMBattleState _BattleState { get; private set; }
    // end state machine

    [SerializeField] private bool ready = false;


    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;

        DontDestroyOnLoad(this.gameObject);
        if (!ready)
        {
            _PlayerManager = GetComponent<GM_PlayerManager>();
            _UI = GetComponent<UI_Controller>();
            _UI.Initialize();

            _MatchSettings = GetComponent<MatchSettings>();

            playerInputManager = GetComponent<PlayerInputManager>();

            _SceneManager = GetComponent<GM_SceneManager>();

            ready = true;
        }
        playerInputManager.DisableJoining();
    }

    private void Start()
    {
        BuildStateMachine();
    }

    private void BuildStateMachine()
    {
        _StateMachine = new GMStateMachine();
        _WaitState = new GMWaitState();
        _StartState = new GMStartGameState();
        _CharacterSelectState = new GMCharacterSelectState();
        _BattleState = new GMBattleState();

        _StateMachine.InitializeStateMachine(_WaitState);
    }

    private void Update()
    {
        if (testMode && ready) StartTestMode();
    }

    private void StartTestMode()
    {
        _UI.TurnOnBattleUI();
        playerInputManager.EnableJoining();
        playerInputManager.JoinPlayer();
        testMode = false;
    }

    public void AllowJoinFromCharacterSelect()
    {
        StartCoroutine(DelayThenEnableJoin());
    }

    private IEnumerator DelayThenEnableJoin()
    {
        yield return new WaitForSeconds(0.35f);
        EnablePlayerJoining(true);
    }

    public void EnablePlayerJoining(bool isEnabled)
    {
        if (isEnabled) playerInputManager.EnableJoining();
        else playerInputManager.DisableJoining();
    }

    // end
}
