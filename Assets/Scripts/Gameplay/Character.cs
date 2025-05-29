using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected Rigidbody _rigidBody;

    [SerializeField]
    protected Stats _stats;

    [SerializeField]
    protected CharacterAttack _characterAttack;

    public virtual void Move(Vector2 movementVector)
    {
        movementVector = movementVector.normalized;

        var deltaMove = new Vector3(movementVector.x, 0, movementVector.y);
        deltaMove *= Time.fixedDeltaTime * _stats.Speed;
        _rigidBody.MovePosition(transform.position + deltaMove);

        transform.LookAt(transform.position + deltaMove);
    }

    public void MoveTo(Vector3 position)
    {
        var movement = position - transform.position;
        Move(new Vector2(movement.x, movement.z));
    }

    public void Attack()
    {
        _characterAttack.Attack();
    }

    public void LookAt(Vector3 position)
    {
        position.y = transform.position.y;
        transform.LookAt(position);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    public void GetDamage(Damage damage)
    {
        _stats.GetDamage(damage);
    }

    public void Awake()
    {
        _stats.OnCharacterDie += Die;
        _stats.Init();
    }
}
