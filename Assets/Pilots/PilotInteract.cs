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
        RaycastHit2D ray = Physics2D.Raycast(interactStart.position, interactStart.right, rayLength, LayerMask.GetMask());
        Color rayColor = Color.white;

        if (ray.collider)
        {
            IInteractable interactable = ray.collider.GetComponentInParent<IInteractable>();
            interactable?.Interact(player._PilotCharacter);
        }
        Debug.DrawRay(interactStart.position, interactStart.right * rayLength, rayColor);
    }

    // end
}
