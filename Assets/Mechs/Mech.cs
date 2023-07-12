using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour, IInteractable
{
    [field: SerializeField] public MechScriptableObj _MechCharacterSheet { get; private set; }
    public bool _CanInteract { get; set; }
    public Transform _Cockpit { get; private set; }
    public MechLocomotion _Movement { get; private set; }

    // State Machine
    public PC_StateMachine _MechStateMachine { get; private set; }
    public MechInactiveState _InactiveState { get; private set; }
    public MechIdleState _IdleState { get; private set; }
    public MechMoveState _MoveState { get; private set; }

    public void InteractionAccess(Pilot pilot)
    {
        print("interacting with a mech");
        if (pilot._Player._Controls._InteractInput)
        {
            pilot._Player._Controls.UseInteract();
            pilot._Player._MechController.GetNewMech(this);
            GetInTheRobot(pilot);
            _CanInteract = false;
            
            BuildStates(pilot._Player);
            _MechStateMachine.InitializeStateMachine(_InactiveState);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _Cockpit = transform.Find("Cockpit");

        _Movement = gameObject.AddComponent<MechLocomotion>();
        _Movement.Initialize(this);
        
        _MechStateMachine = new PC_StateMachine();
        
        _CanInteract = true;
    }

    private void BuildStates(Player player)
    {
        _InactiveState = new MechInactiveState(player, _MechStateMachine, "inactive");
        _IdleState = new MechIdleState(player, _MechStateMachine, "idle");
        _MoveState = new MechMoveState(player, _MechStateMachine, "move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInTheRobot(Pilot pilot)
    {
        pilot._Player._StateMachine.ChangeState(pilot._EmbarkState);
    }

    public void GetOutTheRobot()
    {
        _MechStateMachine.ChangeState(_InactiveState);
        _CanInteract = true;

        _IdleState = null;
    }
}
