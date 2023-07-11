using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotLocomotion : MonoBehaviour
{
    private Player player;
    public Rigidbody2D _PhysicsController { get; private set; }
    private Vector2 moveForces;
    public CheckForGround _CheckGrounded { get; private set; }

    [field: SerializeField] public bool _IsFacingRight { get; private set; }

    public float dashTimer { get; private set; }

    // Start is called before the first frame update
    public void Initialize(Player _player)
    {
        player = _player;
        moveForces = player._PilotSO.movementForce;
        _PhysicsController = GetComponent<Rigidbody2D>();
        _CheckGrounded = gameObject.AddComponent<CheckForGround>();
        _IsFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        ControlDashTimer();
    }

    private void ControlDashTimer()
    {
        if (dashTimer > 0) dashTimer -= Time.deltaTime;
        else if (dashTimer <= 0) dashTimer = 0;
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

    public void StopMovement()
    {
        _PhysicsController.velocity = Vector2.zero;
    }

    public void Dash(Vector2 direction)
    {
        if (dashTimer <= 0)
        {
            dashTimer = player._PilotSO.dashTime;
            _PhysicsController.velocity = new Vector2((transform.localScale.x * player._PilotSO.dashPower) * direction.x, (transform.localScale.y * player._PilotSO.dashPower) * direction.y);
        }
    }

    private void Flip()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
        _IsFacingRight = !_IsFacingRight;
    }
}