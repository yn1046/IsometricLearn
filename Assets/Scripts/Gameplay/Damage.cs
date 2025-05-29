using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    private float _damageAmount;

    private Team _sourceTeam;
    public Team SourceTeam { get { return _sourceTeam; } }

    public Damage(float damageAmount)
    {
        _damageAmount = damageAmount;
    }

    public Damage(float damageAmount, Team sourceTeam) : this(damageAmount)
    {
        _sourceTeam = sourceTeam;
    }

    public float DamageAmount { get => _damageAmount; }
}
