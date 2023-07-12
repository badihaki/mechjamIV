using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotMech : MonoBehaviour
{
    public Pilot _Pilot { get; private set; }
    public Mech _Mech;

    public void Initialize(Pilot pilotCharacter)
    {
        _Pilot = pilotCharacter;
    }

    public void KeepPilotInMech() => _Pilot.transform.position = _Mech.transform.position;

    public void GetNewMech(Mech newMech) => _Mech = newMech;
    public void DiscardMech() => _Mech = null;

    // end
}
