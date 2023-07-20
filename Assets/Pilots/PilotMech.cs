using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotMech : MonoBehaviour
{
    [field: SerializeField] public Pilot _Pilot { get; private set; }
    [field: SerializeField] public Mech _Mech { get; private set; }

    public void Initialize(Pilot pilotCharacter)
    {
        _Pilot = pilotCharacter;
    }

    public void KeepPilotInMech() => _Pilot.transform.position = _Mech._Cockpit.position;

    public void GetNewMech(Mech newMech) => _Mech = newMech;
    public void DiscardMech() => _Mech = null;

    // end
}
