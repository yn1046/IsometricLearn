using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField]
    private Transform _slashVFX;

    [SerializeField]
    private Collider _collider;

    [SerializeField]
    private Stats _stats;
    public Stats Stats { get { return _stats; } }

    private bool _canAttack = true;

    public void Attack()
    {
        if (_canAttack) StartCoroutine(AttackRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageTarget = other.GetComponent<IDamageable>();
        if (damageTarget != null)
        {
            damageTarget.GetDamage(new Damage(_stats.Damage, _stats.Team));
        }
    }

    private IEnumerator AttackRoutine()
    {
        _canAttack = false;
        _collider.enabled = true;
        _slashVFX.gameObject.SetActive(false);
        _slashVFX.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        _collider.enabled = false;
        yield return new WaitForSeconds(0.7f);
        _canAttack = true;
    }

}
