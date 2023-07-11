using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Pilot", menuName = "Create Content/Create New Pilot")]
public class PilotScriptableObject : ScriptableObject
{
    [Header("Basic stuff")]
    public string pilotName;
    public GameObject pilotGameObj;

    [Header("Stats")]
    public Vector2 movementForce;
    public float dashPower;
    public float dashTime;
}
