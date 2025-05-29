using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyCharacterController : CharacterController
{
    [SerializeField]
    private float aggroDistance = 30;
    private bool _aggred = false;

    [SerializeField]
    private float attackPeriod;
    private float _nextAttackTime;

    private float _nextPathRecalcTime = 0;
    private NavMeshPath _path;
    private int _nextCornerIndex;

    protected override void ProcessInput(Character target)
    {
        Character player = Game.Instance.Player.PlayerCharacter;
        Vector3 pos = player.transform.position;
        if (!_aggred && Vector3.Distance(pos, target.transform.position) < aggroDistance)
        {
            _aggred = true;
        }
        else if (!_aggred) return;

        if (Time.time > _nextAttackTime)
        {
            _nextAttackTime = Time.time + attackPeriod;
            target.Attack();
        }

        if (Time.time > _nextPathRecalcTime)
        {
            _path = new NavMeshPath();
            NavMesh.CalculatePath(target.transform.position, pos, NavMesh.AllAreas, _path);
            _nextCornerIndex = 1;
            _nextPathRecalcTime += 0.25f;
        }
        target.LookAt(pos);
        //target.MoveTo(pos);
        if (_path is not null && _path.corners.Length > _nextCornerIndex)
        {
            target.MoveTo(_path.corners[_nextCornerIndex]);
            if (Vector3.Distance(target.transform.position, _path.corners[_nextCornerIndex]) < 0.1f)
            {
                _nextCornerIndex++;
            }
        }
    }
}