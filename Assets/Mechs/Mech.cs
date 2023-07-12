using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour, IInteractable
{
    public bool _CanInteract { get; set; }
    public Transform _Cockpit { get; private set; }

    public void InteractionAccess(Pilot pilot)
    {
        print("interacting with a mech");
        if (pilot._Player._Controls._InteractInput)
        {
            pilot._Player._Controls.UseInteract();
            pilot._Player._Mech.GetNewMech(this);
            GetInTheRobot(pilot);
            _CanInteract = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _CanInteract = true;
        _Cockpit = transform.Find("Cockpit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInTheRobot(Pilot pilot)
    {
        print("you want " + pilot.name + " to baord a mech");
        pilot._Player._StateMachine.ChangeState(pilot._EmbarkState);
    }
}
