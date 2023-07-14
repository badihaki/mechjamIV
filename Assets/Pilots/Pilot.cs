using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    public Player _Player { get; private set; }
    public GameObject _Body { get; private set; }

    // States listed below
    public Pilot_IdleState _IdleState { get; private set; }
    public Pilot_MoveState _MoveState { get; private set; }
    public Pilot_JumpState _JumpState { get; private set; }
    public Pilot_FallingState _FallingState { get; private set; }
    public Pilot_DashState _DashState { get; private set; }
    public Pilot_DeadState _DeadState { get; private set; }
    public PilotEmbarkState _EmbarkState { get; private set; }
    public PilotRidingMechState _RidingMechState { get; private set; }
    public PilotDisembarkState _DisembarkState { get; private set; }
    
    public void InitiatePilot(Player _player)
    {
        _Player = _player;
        _Body = transform.Find("Body").gameObject;

        // BuildStates();
    }
    public virtual void BuildStates()
    {
        _IdleState = new Pilot_IdleState(_Player, _Player._StateMachine, "idle");
        _MoveState = new Pilot_MoveState(_Player, _Player._StateMachine, "move");
        _JumpState = new Pilot_JumpState(_Player, _Player._StateMachine, "air");
        _FallingState = new Pilot_FallingState(_Player, _Player._StateMachine, "air");
        _DashState = new Pilot_DashState(_Player, _Player._StateMachine, "dash");
        _DeadState = new Pilot_DeadState(_Player, _Player._StateMachine, "dead");

        // vehicle states
        _EmbarkState = new PilotEmbarkState(_Player, _Player._StateMachine, "vehicle");
        _RidingMechState = new PilotRidingMechState(_Player, _Player._StateMachine, "vehicle");
        _DisembarkState = new PilotDisembarkState(_Player, _Player._StateMachine, "air");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
