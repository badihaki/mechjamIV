using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Create Content/Create New Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public GameObject weaponGameObj;
    public Projectile projectile;
    public float projectileFireRate;
    public float projectileSpeed;
    public int projectileDamage;
    public float projectileForce;
    public Sprite pickupGraphic;
    public GameObject weaponPickup;
}
