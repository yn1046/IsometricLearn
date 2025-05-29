using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private float _hp;
    public float Hp { get { return _hp; } }

    [SerializeField]
    private float _maxHp = 10.0f;
    public float MaxHp { get { return _maxHp; } }

    [SerializeField]
    [Range(0f, 1.0f)]
    private float _armor = 0;
    public float Armor { get { return _armor; } }

    [SerializeField]
    private float _damage = 5.5f;
    public float Damage { get { return _damage; } }

    [SerializeField]
    private Team _team;
    public Team Team { get { return _team; } }


    public float Speed { get => _speed; }

    public void GetDamage(Damage damage)
    {
        if (_team == damage.SourceTeam) return;

        _hp -= damage.DamageAmount / (1 + _armor);
        if (_hp <= 0)
        {
            OnCharacterDie?.Invoke();
        }

    }

    public event Action OnCharacterDie;

    public void Init()
    {
        _hp = _maxHp;
    }
}
