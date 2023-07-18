using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPilotSelector : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<PilotScriptableObject> pilotCharacters;

    public void Initialize(Player _player)
    {
        player = _player;

        pilotCharacters = GameMaster.Instance.PlayerManager._PilotTemplates;
    }

    // end
}
