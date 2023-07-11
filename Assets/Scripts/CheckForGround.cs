using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGround : MonoBehaviour
{
    public float rayDistance = 0.350f;
    public Vector3 rayOffsetOnSide = new Vector3(0.13f, 0.0f, 0.0f);
    public Collider2D body;
    public LayerMask groundLayers;

    private void Awake()
    {
        body = transform.Find("Body").GetComponent<Collider2D>();
        rayOffsetOnSide = new Vector3(body.bounds.extents.x, 0.0f, 0.0f);
        groundLayers = LayerMask.GetMask("Walkable");
    }

    public bool IsGrounded()
    {
        bool groundIsDetected = false;

        Color midRayColor = Color.red;
        Color sideRayColor = Color.green;
        Color otherSideRayColor = Color.green;

        RaycastHit2D middleRay = Physics2D.Raycast(body.bounds.center, Vector2.down, rayDistance, groundLayers);
        RaycastHit2D sideRay = Physics2D.Raycast(body.bounds.center + rayOffsetOnSide, Vector2.down, rayDistance, groundLayers);
        RaycastHit2D otherSideRay = Physics2D.Raycast(body.bounds.center - rayOffsetOnSide, Vector2.down, rayDistance, groundLayers);

        Debug.DrawRay(body.bounds.center, Vector2.down * rayDistance, midRayColor);
        Debug.DrawRay(body.bounds.center + rayOffsetOnSide, Vector2.down * rayDistance, sideRayColor);
        Debug.DrawRay(body.bounds.center - rayOffsetOnSide, Vector2.down * rayDistance, otherSideRayColor);


        if (middleRay.collider)
        {
            midRayColor = Color.blue;
            Debug.DrawRay(body.bounds.center, Vector2.down * rayDistance, midRayColor);

            groundIsDetected = true;
        }
        if (sideRay.collider)
        {
            sideRayColor = Color.blue;
            Debug.DrawRay(body.bounds.center + rayOffsetOnSide, Vector2.down * rayDistance, sideRayColor);

            groundIsDetected = true;
        }
        if (otherSideRay.collider)
        {
            otherSideRayColor = Color.blue;
            Debug.DrawRay(body.bounds.center - rayOffsetOnSide, Vector2.down * rayDistance, otherSideRayColor);

            groundIsDetected = true;
        }

        return groundIsDetected;
        // Debug.DrawLine(body.bounds.center, new Vector3(transform.position.x, -rayDistance, transform.position.z), midRayColor);
    }
}
