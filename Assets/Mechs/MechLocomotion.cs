using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechLocomotion : MonoBehaviour
{
    private Mech mech;
    public Rigidbody2D _PhysicsController { get; private set; }
    public bool _IsFacingRight { get; private set; }
    private Vector2 moveForces;
    public CheckForGround _CheckGrounded { get; private set; }


    public void Initialize(Mech mecha)
    {
        mech = mecha;
        _CheckGrounded = gameObject.AddComponent<CheckForGround>();

        _PhysicsController = GetComponent<Rigidbody2D>();
        moveForces = mech._MechCharacterSheet.movementForce;

        _IsFacingRight = true;
        int willFlip = Random.Range(1, 7);
        if (willFlip >= 3)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMovement()
    {
        // _PhysicsController.velocity = Mathf.Lerp(_PhysicsController.velocity, Vector2.zero, 0.35f);
        _PhysicsController.velocity = new Vector2(
            Mathf.Lerp(_PhysicsController.velocity.x, 0, 0.35f),
            Mathf.Lerp(_PhysicsController.velocity.y, 0, 0.35f)) * Time.deltaTime;
    }

    public void MoveCharacterHorizontal(float direction)
    {
        _PhysicsController.velocity = new Vector2(direction * moveForces.x, _PhysicsController.velocity.y);

        if (direction > 0 && !_IsFacingRight) Flip();
        else if (direction < 0 && _IsFacingRight) Flip();
    }

    public void JumpCharacter()
    {
        _PhysicsController.AddForce(new Vector2(_PhysicsController.velocity.x / 2, mech._MechCharacterSheet.movementForce.y), ForceMode2D.Impulse);
    }

    private void Flip()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
        _IsFacingRight = !_IsFacingRight;
    }

    // end
}
