using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect Instance;

    private CharacterSelectHelper helper;
    public Transform[] playerPoints;

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

    // end
}
