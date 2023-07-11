using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform holder;
    private Pilot pilot;
    [field: SerializeField] public Transform projectileSpawnPoint { get; private set; }
    
    public void BuildWeaponInstance(Transform _holder, Pilot _pilot)
    {
        holder = _holder;
        pilot = _pilot;

        projectileSpawnPoint = transform.Find("Projectile Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = holder.position;
        transform.rotation = holder.rotation;
    }
}
