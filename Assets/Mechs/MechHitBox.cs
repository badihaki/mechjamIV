using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechHitBox : MonoBehaviour
{
    [SerializeField] private Mech controllingMech;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger == true)
        {
            Health target = collider.GetComponentInParent<Health>();
            if (target && target.transform != controllingMech.transform)
            {
                IDamageable damagedObj = target.GetComponent<IDamageable>();
                if (damagedObj != null)
                {
                    damagedObj.Damage(controllingMech.transform, controllingMech._Force, controllingMech._Damage);
                }
            }
        }
    }
}
