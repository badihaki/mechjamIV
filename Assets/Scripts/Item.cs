using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool _CanInteract { get; set; }

    public void Interact(Pilot pilot)
    {
        print(pilot.name + " is interacting with " + name);

        if (pilot._Player._Controls._InteractInput)
        {
            print("*** " + pilot.name + " interacted with item " + name + " ***");
            pilot._Player._Controls.UseInteract();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _CanInteract = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
