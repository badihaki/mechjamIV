using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private GameObject battleUIObj;
    [field: SerializeField] public BattleUI _BattleUI { get; private set; }


    public void Initialize()
    {
        battleUIObj = Instantiate(battleUIObj, GameMaster.Instance.transform);
        _BattleUI = battleUIObj.GetComponent<BattleUI>();
        _BattleUI.Initialize();
        battleUIObj.SetActive(false);

        // initalize other ui
    }

    public void TurnOnBattleUI()
    {
        battleUIObj?.SetActive(true);

        // _BattleUI.AddPlayers(GameMaster.Instance.PlayerManager._PlayerList.ToArray());
    }
        

    // end
}
