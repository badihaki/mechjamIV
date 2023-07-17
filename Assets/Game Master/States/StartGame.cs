using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : GMState
{
    public override void Enter()
    {
        base.Enter();

        EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        eventSystem.firstSelectedGameObject = GameObject.Find("Start Button");    }
}
