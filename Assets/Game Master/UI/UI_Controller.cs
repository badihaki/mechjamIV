using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [Header("Battle")]
    [SerializeField] private GameObject battleUIObj;
    [field: SerializeField] public BattleUI _BattleUI { get; private set; }

    [Header("Match Finish")]
    [SerializeField] private GameObject winLoseObj;
    [field: SerializeField] public MatchFinishUI _WinLoseUI { get; private set; }

    public void Initialize()
    {
        battleUIObj = Instantiate(battleUIObj, GameMaster.Instance.transform);
        _BattleUI = battleUIObj.GetComponent<BattleUI>();
        _BattleUI.Initialize();
        battleUIObj.SetActive(false);

        winLoseObj = Instantiate(winLoseObj, GameMaster.Instance.transform);
        _WinLoseUI = winLoseObj.GetComponent<MatchFinishUI>();
        _WinLoseUI.Initialize();
        winLoseObj.SetActive(false);
        // initalize other ui
    }

    public void TurnOnBattleUI()
    {
        print("Turnin on battle ui");
        if(!battleUIObj.activeInHierarchy) battleUIObj.SetActive(true);
        // battleUIObj?.SetActive(true);
    }
    public void TurnOnWinLoseUI()
    {
        if (!winLoseObj.activeInHierarchy) winLoseObj.SetActive(true);
    }
        

    // end
}
