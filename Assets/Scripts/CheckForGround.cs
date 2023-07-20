using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckForGround : MonoBehaviour
{
    public float rayDistance = 0.050f;
    public Vector3 rayOffset = new Vector3(0.13f, 0.0f, 0.0f);
    public Collider2D body;
    public LayerMask groundLayers;

    private void Awake()
    {
        body = transform.Find("Body").GetComponent<Collider2D>();
        // rayOffsetOnSide = new Vector3(body.bounds.extents.x, 0.0f, 0.0f);
        rayOffset = Vector3.zero;
        rayOffset.x = body.bounds.extents.x;
        rayOffset.y = body.bounds.extents.y;
        groundLayers = LayerMask.GetMask("Walkable");
    }

    public bool IsGrounded()
    {
        bool groundIsDetected = false;

        Color midRayColor = Color.red;
        Color sideRayColor = Color.green;
        Color otherSideRayColor = Color.green;

        Vector3 middlePos = new Vector3(body.bounds.center.x, body.bounds.center.y - rayOffset.y, body.bounds.center.z);
        Vector3 leftPos = new Vector3(body.bounds.center.x - rayOffset.x, body.bounds.center.y - rayOffset.y, body.bounds.center.z);
        Vector3 rightPos = new Vector3(body.bounds.center.x + rayOffset.x, body.bounds.center.y - rayOffset.y, body.bounds.center.z);

        RaycastHit2D middleRay = Physics2D.Raycast(middlePos, Vector2.down, rayDistance, groundLayers);
        RaycastHit2D sideRay = Physics2D.Raycast(leftPos, Vector2.down, rayDistance, groundLayers);
        RaycastHit2D otherSideRay = Physics2D.Raycast(rightPos, Vector2.down, rayDistance, groundLayers);

        Debug.DrawRay(middlePos, Vector2.down * rayDistance, midRayColor);
        Debug.DrawRay(leftPos, Vector2.down * rayDistance, sideRayColor);
        Debug.DrawRay(rightPos, Vector2.down * rayDistance, otherSideRayColor);


        if (middleRay.collider)
        {
            midRayColor = Color.blue;
            Debug.DrawRay(body.bounds.center, Vector2.down * rayDistance, midRayColor);

            groundIsDetected = true;
        }
        if (sideRay.collider)
        {
            sideRayColor = Color.blue;
            Debug.DrawRay(body.bounds.center + rayOffset, Vector2.down * rayDistance, sideRayColor);

            groundIsDetected = true;
        }
        if (otherSideRay.collider)
        {
            otherSideRayColor = Color.blue;
            Debug.DrawRay(body.bounds.center - rayOffset, Vector2.down * rayDistance, otherSideRayColor);

            groundIsDetected = true;
        }

        return groundIsDetected;
        // Debug.DrawLine(body.bounds.center, new Vector3(transform.position.x, -rayDistance, transform.position.z), midRayColor);
    }
}
