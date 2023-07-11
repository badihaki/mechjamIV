using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PilotAttack : MonoBehaviour
{
    private Pilot pilot;
    [field: SerializeField] public WeaponScriptableObject _WeaponSheet { get; private set; }
    [field: SerializeField] public Transform _WeaponHolder { get; private set; }
    [field: SerializeField] public Weapon _Weapon { get; private set; }
    [SerializeField] private Transform projectileSpawnPoint;
    private float attackTimer;

    public void Initialize(Pilot _pilot, WeaponScriptableObject _startingWeapon)
    {
        pilot = _pilot;

        _WeaponHolder = transform.Find("Weapon Holder");
        _WeaponSheet = _startingWeapon;

        _Weapon = Instantiate(_WeaponSheet.weaponGameObj, _WeaponHolder).GetComponent<Weapon>();
        _Weapon.BuildWeaponInstance(_WeaponHolder, GetComponent<Pilot>());
    }

    // Update is called once per frame
    void Update()
    {
        ManageAttackTimer();
    }

    public void AimWeapon(Vector2 aim)
    {
        bool facingRight = pilot._Player._Movement._IsFacingRight;
        Vector3 targetRotation = Vector3.zero;

        if(aim.y > 0.35f)
        {
            if (aim.x != 0.0f)
                targetRotation = new Vector3(pilot.transform.rotation.x, pilot.transform.rotation.y, 45.0f);
            else
                targetRotation = new Vector3(pilot.transform.rotation.x, pilot.transform.rotation.y, 90.0f);
        }
        else if (aim.y < -0.35f)
        {
            if (aim.x != 0.0f)
                targetRotation = new Vector3(pilot.transform.rotation.x, pilot.transform.rotation.y, -45.0f);
            else
                targetRotation = new Vector3(pilot.transform.rotation.x, pilot.transform.rotation.y, -90.0f);
        }

        if (!facingRight) targetRotation.y = 180.0f;
        _WeaponHolder.eulerAngles = targetRotation;
    }

    public void Attack()
    {
        if (attackTimer <= 0.0f)
        {
            attackTimer = _WeaponSheet.projectileFireRate;
            Projectile shot = Instantiate(_WeaponSheet.projectile, _Weapon.projectileSpawnPoint.position, _WeaponHolder.rotation);
            shot.InitializeProjectile(pilot._Player.transform, _WeaponSheet.projectileSpeed, _WeaponSheet.projectileDamage, _WeaponSheet.projectileForce);
        }
    }

    public void ManageAttackTimer()
    {
        if (attackTimer > 0.0f) attackTimer -= Time.deltaTime;
        else if (attackTimer <= 0.0f) attackTimer = 0.0f;
    }

    // end
}
