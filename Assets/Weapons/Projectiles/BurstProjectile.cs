using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstProjectile : Projectile
{
    public override void InitializeProjectile(Transform _origin, WeaponScriptableObject weaponStats)
    {
        projectileCreator = _origin;

        StartCoroutine(BurstFire(weaponStats));
    }

    private IEnumerator BurstFire(WeaponScriptableObject stats)
    {
        float waitTime = stats.projectileFireRate * 0.0837f;
        
        Projectile projectile1 = Instantiate(projectileSubEmittr, projectileCreator.position, transform.rotation);
        projectile1.InitializeProjectile(projectileCreator, stats);
        projectile1.transform.position = transform.position;
        yield return new WaitForSeconds(waitTime);
        
        Projectile projectile2 = Instantiate(projectileSubEmittr, projectileCreator.position, transform.rotation);
        projectile2.InitializeProjectile(projectileCreator, stats);
        projectile2.transform.position = transform.position;
        yield return new WaitForSeconds(waitTime);

        Projectile projectile3 = Instantiate(projectileSubEmittr, projectileCreator.position, transform.rotation);
        projectile3.transform.position = transform.position;
        projectile3.InitializeProjectile(projectileCreator, stats);
        
        Destroy(gameObject);
    }

    // end
}
