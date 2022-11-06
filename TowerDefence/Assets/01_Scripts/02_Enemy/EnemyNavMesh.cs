using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : Enemy_BH
{
    [SerializeField]private NavMeshAgent _navMeshAgent;

    protected override void OnEnable()
    {
        base.OnEnable();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _enemyData._speed;

    }
    public override void moveToTarget(Vector3 target)
    {
        _navMeshAgent.SetDestination(target);
    }

    public override void CheckTarget()
    {
        if (_navMeshAgent.remainingDistance <= 0.1f)
        {
            PathPoint tmp = _currentTarget.gameObject.GetComponent<PathPoint>();
            if (tmp != null) { 
                    _currentTarget = ChangeTarget(tmp);
                    _navMeshAgent.SetDestination(_currentTarget.transform.position);
            }
            else
                _currentTarget = null;
        }
    }
}
