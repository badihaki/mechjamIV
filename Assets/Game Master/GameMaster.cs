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

    [SerializeField] private bool testMode;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;

        PlayerManager = GetComponent<GM_PlayerManager>();
        _UI = GetComponent<UI_Controller>();
        _UI.Initialize();

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (testMode) StartCoroutine(StartTestMode());
    }

    private IEnumerator StartTestMode()
    {
        // Instantiate(GetComponent<PlayerInputManager>().playerPrefab);
        GetComponent<PlayerInputManager>().JoinPlayer();

        yield return new WaitForSeconds(1.0f);

        _UI.TurnOnBattleUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // end
}
