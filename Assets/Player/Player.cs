using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public Health _Health { get; private set; }
    [field: SerializeField] public PlayerControls _Controls { get; private set; }
    [field: SerializeField] public PlayerEffects _Effects { get; private set; }

    // pilot stuff
    [field: SerializeField] public PilotScriptableObject _PilotSO { get; private set; }
    [field: SerializeField] public Pilot _PilotCharacter { get; private set; }
    [field: SerializeField] public PilotLocomotion _Movement { get; private set; }
    [field: SerializeField] public PilotAttack _Attack { get; private set; }
    [SerializeField] private WeaponScriptableObject _startingWeapon;

    public PC_StateMachine _StateMachine { get; private set; }
    

    private bool ready;

    // Start is called before the first frame update
    void Start()
    {
        // InitializePlayer();
    }

    public void InitializePlayer()
    {
        ready = false;
        _Controls = GetComponent<PlayerControls>();
        BuildInGamePlayerCharacter();
        _Effects = GetComponent<PlayerEffects>();
        _Effects.InitializeEffects(_PilotCharacter);
        _Health = gameObject.AddComponent<Health>();
        _Health.SetLives();
    }

    private void BuildInGamePlayerCharacter()
    {
        _PilotCharacter = Instantiate(_PilotSO.pilotGameObj, transform).GetComponent<Pilot>();
        _PilotCharacter.name = "Pilot-" + GetComponent<PlayerInput>().playerIndex;

        _Movement = _PilotCharacter.gameObject.AddComponent<PilotLocomotion>();
        _Movement.Initialize(this);
        
        _Attack = _PilotCharacter.gameObject.AddComponent<PilotAttack>();
        _Attack.Initialize(_PilotCharacter, _startingWeapon);

        _StateMachine = new PC_StateMachine();
        _PilotCharacter.InitiatePilot(this);
        _StateMachine.InitializeStateMachine(_PilotCharacter._IdleState);

        int index = UnityEngine.Random.Range(0, GameMaster.Instance.PlayerManager._PlayerSpawnPoints.Count - 1);
        PilotSpawnPoint spawnPoint = GameMaster.Instance.PlayerManager._PlayerSpawnPoints[index];

        _PilotCharacter.transform.position = spawnPoint.transform.position;

        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ready)
        {
            _StateMachine.currentState.LogicUpdate();
        }
    }
    private void FixedUpdate()
    {
        if (ready)
        {
            _StateMachine.currentState.PhysicsUpdate();
        }
    }

    public void Damage(Transform origin, Vector2 force, int damage)
    {
        _StateMachine.ChangeState(_PilotCharacter._DeadState);

        _Movement.Pushback(CalculatedPushback(origin, force));
    }

    private Vector2 CalculatedPushback(Transform origin, Vector2 force)
    {
        Vector2 pushback = Vector2.one;

        // calculate x
        if (origin.position.x > _PilotCharacter.transform.position.x) pushback.x = -1;
        print("hit object x=" + _PilotCharacter.transform.position.x + " hit by object x=" + origin.position.x);
        // calculate y
        if (origin.position.y > _PilotCharacter.transform.position.y) pushback.y = -1;
        print("hit object y=" + _PilotCharacter.transform.position.y + " hit by object y=" + origin.position.y);


        pushback *= force;

        return pushback;
    }

    public void Respawn()
    {
        Destroy(_PilotCharacter.transform.Find("Hurtbox").gameObject);
        _PilotCharacter = null;
        if (_Health.lives > 0)
        {
            _Health.TakeALife();
            BuildInGamePlayerCharacter();
        }
        else LoseGame();
    }

    private void LoseGame()
    {
        /*
         * When we lose the game we'll send a message to the game master that this player is dead.
         */
        Destroy(this);
    }
}
