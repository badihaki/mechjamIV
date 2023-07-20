using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mech", menuName = "Create Content/Create New Mech")]
public class MechScriptableObj : ScriptableObject
{
    [Header("Basic stuff")]
    public GameObject mechGameObj;

    [Header("Stats")]
    public Vector2 movementForce;
    public float dashPower;
    public float dashTime;
    public int mechHealh;
}
