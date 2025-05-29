using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float _HP = 10.0f;

    public void GetDamage(Damage damage)
    {
        _HP -= damage.DamageAmount;
        if (_HP <= 0) DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
