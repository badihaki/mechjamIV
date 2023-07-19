using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Vector2 force;
    [SerializeField] protected Transform projectileCreator;

    [SerializeField] private Rigidbody2D physicsController;

    [SerializeField] private bool ready = false;

    [SerializeField] private ParticleSystem deathEffect;

    [field: SerializeField] public Projectile projectileSubEmittr { get; protected set; }

    public virtual void InitializeProjectile(Transform _origin, WeaponScriptableObject weaponStats)
    {
        // speed = _speed;
        speed = weaponStats.projectileSpeed;
        projectileCreator = _origin;
        // damage = _dmg;
        damage = weaponStats.projectileDamage;
        // force = new Vector2(_force, _force);
        force = new Vector2(weaponStats.projectileForce, weaponStats.projectileForce);

        physicsController = GetComponent<Rigidbody2D>();

        ready = true;
        Destroy(gameObject, 2.0f);
    }

    private void FixedUpdate()
    {
        if (ready)
        {
            physicsController.velocity = transform.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (ready && collider.isTrigger == true)
        {
            Health target =  collider.GetComponentInParent<Health>();
            if (target && target.transform != projectileCreator)
            {
                IDamageable damagedObj = target.GetComponent<IDamageable>();
                if (damagedObj != null)
                {
                    damagedObj.Damage(transform, force, damage);
                    Instantiate(deathEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
    }


    // end
}
