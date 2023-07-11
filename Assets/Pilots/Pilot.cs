using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    [field: SerializeField] public PilotScriptableObject _PilotCharacterSheet { get; private set; }
    [field: SerializeField] public Player player { get; private set; }

    // States listed below
    public Pilot_IdleState _IdleState { get; private set; }
    public Pilot_MoveState _MoveState { get; private set; }
    public Pilot_JumpState _JumpState { get; private set; }
    public Pilot_FallingState _FallingState { get; private set; }
    public Pilot_DashState _DashState { get; private set; }
    public Pilot_DeadState _DeadState { get; private set; }
    
    public void InitiatePilot(Player _player)
    {
        player = _player;

        BuildStates();
    }
    protected virtual void BuildStates()
    {
        _IdleState = new Pilot_IdleState(player, player._StateMachine, "idle");
        _MoveState = new Pilot_MoveState(player, player._StateMachine, "move");
        _JumpState = new Pilot_JumpState(player, player._StateMachine, "air");
        _FallingState = new Pilot_FallingState(player, player._StateMachine, "air");
        _DashState = new Pilot_DashState(player, player._StateMachine, "dash");
        _DeadState = new Pilot_DeadState(player, player._StateMachine, "dead");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
