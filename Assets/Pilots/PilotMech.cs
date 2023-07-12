using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotMech : MonoBehaviour
{
    public Pilot pilot { get; private set; }
    public Mech mech;

    public void Initialize(Pilot pilotCharacter)
    {
        pilot = pilotCharacter;
    }

    public void KeepPilotInMech() => pilot.transform.position = mech.transform.position;

    public void GetNewMech(Mech newMech) => mech = newMech;
    public void DiscardMech() => mech = null;

    // end
}
