using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotInteract : MonoBehaviour
{
    private Player player;
    [SerializeField] private float rayLength;
    [field: SerializeField] public IInteractable activeInteractable;
    private Transform interactStart;

    public void Initialize(Player _player, float length = 1.25f)
    {
        player = _player;
        rayLength = length;
        interactStart = transform.Find("Interact");
    }

    public void DetectInteract()
    {
        RaycastHit2D ray = Physics2D.Raycast(interactStart.position, transform.forward, rayLength, LayerMask.GetMask());
        Color rayColor = Color.white;
        
        if (ray.collider != null)
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, rayColor);
            Debug.Log("searching");
            if (ray.collider.name == "Body" && ray.collider.transform.parent != player._PilotCharacter)
            {
                IInteractable interactable = ray.collider.GetComponentInParent<IInteractable>();
                if (interactable != null)
                {
                    rayColor = Color.green;
                    print("hitting" + ray.transform.parent.name);
                }
                else
                {
                    if (activeInteractable != null) activeInteractable = null;
                }
            }
        }
        Debug.DrawRay(transform.position, transform.forward * rayLength, rayColor);
    }

    // end
}
