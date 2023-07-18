using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    private CharacterSelectHelper helper;

    // Start is called before the first frame update
    void Start()
    {
        GameMaster.Instance._StateMachine.ChangeState(GameMaster.Instance._CharacterSelectState);
        helper = GetComponentInChildren<CharacterSelectHelper>();

        helper.StartHelper();
    }

    // end
}
