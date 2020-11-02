﻿using System;
using UnityEngine;

public class BulletProjectile : MonoBehaviour, IDamager, IOriginDerived
{
    [SerializeField] private Rigidbody2D bulletRigidbody;
    [SerializeField] private float damage;
    
    public event Action<IDamagable> OnDamaged;
    
    public GameObject Origin { get; set; }

    public void Launch(Vector3 velocity)
    {
        bulletRigidbody.AddForce(velocity);
    }

    public void Damage(IDamagable damagable)
    {
        damagable.TakeDamage(new DamageArgs(Origin, gameObject, damage));
        OnDamaged?.Invoke(damagable);
    }
}
