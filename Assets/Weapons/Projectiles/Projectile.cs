using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Vector2 force;
    [SerializeField] private Transform projectileCreator;

    [SerializeField] private Rigidbody2D physicsController;

    [SerializeField] private bool ready = false;

    [SerializeField] private ParticleSystem deathEffect;

    public void InitializeProjectile(Transform _origin, float _speed, int _dmg, float _force)
    {
        speed = _speed;
        projectileCreator = _origin;
        damage = _dmg;
        force = new Vector2(_force, _force);

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
        IDamageable damagedObj = collider.GetComponentInParent<IDamageable>();
        if (damagedObj != null)
        {
            Health target =  collider.GetComponentInParent<Health>();
            
            if (target.transform != projectileCreator)
            {
                damagedObj.Damage(transform, force, damage);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }


    // end
}
