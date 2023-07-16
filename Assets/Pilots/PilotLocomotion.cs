using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotLocomotion : MonoBehaviour
{
    private Player player;
    public Rigidbody2D _PhysicsController { get; private set; }
    private Vector2 moveForces;
    [field: SerializeField] public CheckForGround _CheckGrounded { get; private set; }

    [field: SerializeField] public bool _IsFacingRight { get; private set; }

    [field: SerializeField] public float dashTimer { get; private set; }
    [field:SerializeField] public int _DashCount { get; private set; }
    [SerializeField] private int currentDashCount;
    public bool _CanDash { get; private set; }

    // Start is called before the first frame update
    public void Initialize(Player _player)
    {
        player = _player;
        moveForces = player._PilotSO.movementForce;
        _PhysicsController = GetComponent<Rigidbody2D>();
        _CheckGrounded = gameObject.AddComponent<CheckForGround>();
        _IsFacingRight = true;
        _CanDash = true;
        _DashCount = 2;
        currentDashCount = _DashCount;
    }

    // Update is called once per frame
    void Update()
    {
        ControlDashTimer();
    }

    private void ControlDashTimer()
    {
        if (dashTimer > 0) dashTimer -= Time.deltaTime;
        else if (dashTimer <= 0)
        {
            if (_CanDash == false && currentDashCount > 0)
            {
                _CanDash = true;
                GameMaster.Instance._UI._BattleUI.SetDash(player.playerIndex, _CanDash);
            }
            dashTimer = 0;
        }
    }
    
    public void StopMovement()
    {
        _PhysicsController.velocity = Vector2.zero;
    }

    public void MoveCharacterHorizontal(float direction)
    {
        _PhysicsController.velocity = new Vector2(direction * moveForces.x, _PhysicsController.velocity.y);

        if (direction > 0 && !_IsFacingRight) Flip();
        else if (direction < 0 && _IsFacingRight) Flip();
    }

    public void JumpCharacter()
    {
        _PhysicsController.AddForce(new Vector2(_PhysicsController.velocity.x / 2, player._PilotSO.movementForce.y), ForceMode2D.Impulse);
    }

    public void Dash(Vector2 direction)
    {
        if (player._Movement._CheckGrounded.IsGrounded())
            dashTimer = player._PilotSO.dashTime * 1.35f;
        else dashTimer = player._PilotSO.dashTime;
        _DashCount--;
        _PhysicsController.velocity = new Vector2((transform.localScale.x * player._PilotSO.dashPower) * direction.x, (transform.localScale.y * player._PilotSO.dashPower) * direction.y);
        player._Controls.UseDash();
        _CanDash = false;
        GameMaster.Instance._UI._BattleUI.SetDash(player.playerIndex, _CanDash);
    }

    public void ResetDash()
    {
        if (currentDashCount != _DashCount && player._Movement._CheckGrounded.IsGrounded())
        {
            currentDashCount = _DashCount;
            _CanDash = true;
            GameMaster.Instance._UI._BattleUI.SetDash(player.playerIndex, _CanDash);
        }
    }

    public void Pushback(Vector2 direction) => _PhysicsController.AddForce(direction, ForceMode2D.Impulse);

    private void Flip()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
        _IsFacingRight = !_IsFacingRight;
    }

    internal void Eject()
    {
        _PhysicsController.AddForce(new Vector2(0.0f, 12.50f), ForceMode2D.Impulse);
    }
}
