using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{
    public static StartMenu Instance { get; private set; }
    [field: SerializeField] public GameObject StartPanel { get; private set; }
    [field: SerializeField] public GameObject GameMenuPanel { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        GameMaster.Instance._StateMachine.ChangeState(GameMaster.Instance._StartState);
    }
    public void Initialize()
    {
        if (StartPanel != null)
        {
            StartPanel.SetActive(true);
            GameMenuPanel.SetActive(false);
        }

        EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        eventSystem.firstSelectedGameObject = GameObject.Find("Start Button");
    }

    public void Start2P() => GameMaster.Instance._SceneManager.ChangeScene("characterSelect");

    public void QuitGame()=> Application.Quit();

    // end
}
