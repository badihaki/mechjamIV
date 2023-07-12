using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool _CanInteract { get; set; }

    void InteractionAccess(Pilot pilot);

}
