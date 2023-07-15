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
    [field: SerializeField] public int ammo { get; private set; }
    [SerializeField] private bool isReloading;

    public void Initialize(Pilot _pilot, WeaponScriptableObject _startingWeapon)
    {
        pilot = _pilot;

        _WeaponHolder = transform.Find("Weapon Holder");
        _WeaponSheet = _startingWeapon;
        EquipNewWeapon();
        ammo = 0;
        isReloading = false;
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
        if (attackTimer <= 0.0f && ammo > 0)
        {
            print(ammo + " ammo");
            attackTimer = _WeaponSheet.projectileFireRate;
            Projectile shot = Instantiate(_WeaponSheet.projectile, _Weapon.projectileSpawnPoint.position, _WeaponHolder.rotation);
            shot.InitializeProjectile(pilot._Player.transform, _WeaponSheet.projectileSpeed, _WeaponSheet.projectileDamage, _WeaponSheet.projectileForce);
            GameMaster.Instance._UI._BattleUI.UseAmmo(pilot._Player.playerIndex);
            ammo--;
            print("now we have " + ammo + " ammo");
            if (ammo <= 0 && !isReloading) StartCoroutine(Reload());
        }
        else if (ammo <= 0 && !isReloading) StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        ammo = 0;
        GameMaster.Instance._UI._BattleUI.SetWeaponReady(pilot._Player.playerIndex, false);
        yield return new WaitForSeconds(_WeaponSheet.weaponReloadTime);
        ammo = _WeaponSheet.maxAmmo;
        GameMaster.Instance._UI._BattleUI.SetWeaponReady(pilot._Player.playerIndex);
        GameMaster.Instance._UI._BattleUI.ResetAmmo(pilot._Player.playerIndex, _WeaponSheet.maxAmmo);
        isReloading = false;
    }

    public void ManageAttackTimer()
    {
        if (attackTimer > 0.0f) attackTimer -= Time.deltaTime;
        else if (attackTimer <= 0.0f) attackTimer = 0.0f;
    }

    public void SwitchWeapon(WeaponScriptableObject newWeapon)
    {
        ThrowAwayOldWeapon();
        UnequipWeapon();
        _WeaponSheet = newWeapon;
        EquipNewWeapon();
    }

    private void EquipNewWeapon()
    {
        _Weapon = Instantiate(_WeaponSheet.weaponGameObj, _WeaponHolder).GetComponent<Weapon>();
        _Weapon.BuildWeaponInstance(_WeaponHolder, GetComponent<Pilot>());
        ammo = _WeaponSheet.maxAmmo;
        // *** set ammo in the UI
        print(pilot._Player);
        GameMaster.Instance._UI._BattleUI.SetWeaponReady(pilot._Player.playerIndex);
    }

    public void UnequipWeapon()
    {
        _WeaponSheet = null;
        Destroy(_Weapon);
    }

    private void ThrowAwayOldWeapon()
    {
        GameObject pickup = Instantiate(_WeaponSheet.weaponPickup, new Vector2(transform.position.x, transform.position.y + 1.35f), Quaternion.identity);
        Vector2 force = Vector2.one;
        force.x = Random.Range(2.5f, 5.5f);
        force.y = Random.Range(4.35f, 6.85f);
        pickup.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        Destroyer destroyer = pickup.AddComponent<Destroyer>();
        destroyer.InitializeDestroyer(6.35f);
    }

    // end
}
