using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour, IInteractable, IDamageable
{
    [field: SerializeField] public MechScriptableObj _MechCharacterSheet { get; private set; }
    [field: SerializeField] public Animator _Animator { get; private set; }
    public bool _CanInteract { get; set; }
    public Transform _Cockpit { get; private set; }
    public MechLocomotion _Movement { get; private set; }
    public Health _Health { get; private set; }
    private Pilot activePilot;
    
    // effects
    [SerializeField] private GameObject sparkFX;
    private bool isSparking;
    [SerializeField] private GameObject smokeFX;
    private bool isSmoking;
    [SerializeField] private GameObject fireFX;
    private bool onFire;

    // stats
    [field: SerializeField] public int _Damage { get; private set; }
    [field: SerializeField] public Vector2 _Force { get; private set; }

    // State Machine
    public PC_StateMachine _MechStateMachine { get; private set; }
    public MechInactiveState _InactiveState { get; private set; }
    public MechIdleState _IdleState { get; private set; }
    public MechMoveState _MoveState { get; private set; }
    public MechJumpState _JumpState { get; private set; }
    public MechFallingState _FallingState { get; private set; }
    public MechLightAttackState _LightAttackState { get; private set; }
    public MechMediumAttackState _MediumAttackState { get; private set; }
    public MechHeavyAttackState _HeavyAttackState { get; private set; }


    public void InteractionAccess(Pilot pilot)
    {
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

        _Animator = GetComponentInChildren<Animator>();
        _Animator.SetBool("inactive", true);

        _Health = gameObject.AddComponent<Health>();
        _Health.SetHealth(_MechCharacterSheet.mechHealh);

        _CanInteract = true;
    }

    private void BuildStates(Player player)
    {
        _InactiveState = new MechInactiveState(player, _MechStateMachine, "inactive");
        _IdleState = new MechIdleState(player, _MechStateMachine, "idle");
        _MoveState = new MechMoveState(player, _MechStateMachine, "move");
        _JumpState = new MechJumpState(player, _MechStateMachine, "jump");
        _FallingState = new MechFallingState(player, _MechStateMachine, "fall");
        _LightAttackState = new MechLightAttackState(player, _MechStateMachine, "lt-attack");
        _MediumAttackState = new MechMediumAttackState(player, _MechStateMachine, "med-attack");
        _HeavyAttackState = new MechHeavyAttackState(player, _MechStateMachine, "hvy-attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_CanInteract) _MechStateMachine.currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        if (!_CanInteract) _MechStateMachine.currentState.PhysicsUpdate();
    }

    public void GetInTheRobot(Pilot pilot)
    {
        pilot._Player._StateMachine.ChangeState(pilot._EmbarkState);

        activePilot = pilot;

        _Animator.SetBool("inactive", false);
    }

    public void GetOutTheRobot()
    {
        _MechStateMachine.ChangeState(_InactiveState);
        _CanInteract = true;

        _IdleState = null;

        activePilot = null;

        _Animator.SetBool("inactive", true);
    }

    public void SetDamage(int damage, float force)
    {
        _Damage = damage;
        _Force = new Vector2(force, force);
    }

    public void ResetDamage()
    {
        _Damage = 0;
        _Force = Vector2.zero;
    }

    public void Damage(Transform origin, Vector2 force, int damage)
    {
        if (!_CanInteract)
        {
            _Health.TakeHealth(damage);
            _Movement.ApplyPushback(origin, force);
            
            if (_Health._Health < 8 && !isSparking)
            {
                print("sparks");
                Instantiate(sparkFX, transform);
                isSparking = true;
            }
            if(_Health._Health < 4 && !isSmoking)
            {
                print("smoke");

                Instantiate(smokeFX, transform);
                isSmoking = true;
            }
            if(_Health._Health < 1 && !onFire)
            {
                print("fire");

                Instantiate(fireFX, transform);
                onFire = true;
            }
            else if (_Health._Health <= 0) StartCoroutine(DestroyMech());
        }
    }

    private IEnumerator DestroyMech()
    {
        yield return new WaitForSeconds(2.5f);
        if (activePilot) activePilot._Player.Damage(transform, new Vector2(5, 5), 50);
        Destroy(gameObject);
    }

    // end
}
