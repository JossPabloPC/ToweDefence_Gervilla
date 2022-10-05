using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BH : Damagable_Body, MoveToTarget_IE
{
    [SerializeField] public Enemy_Data  _enemyData;
    [SerializeField] private PathPoint  _currentTarget;


    private void Start()
    {
        _currentHealth = _enemyData._health;
    }
    private void Update()
    {
        if (_currentTarget != null)
        {
            moveToTarget(_currentTarget.gameObject.transform.position);
            CheckTarget();
        }
    }

    public void moveToTarget(Vector3 target)
    {
        Vector3 direction = target - gameObject.transform.position;
        gameObject.transform.Translate(direction.normalized * _enemyData._speed * Time.deltaTime);
    }

    public float GetDistanceToTarget(Vector3 target)
    {
        return (gameObject.transform.position - target).magnitude;
    }

    public PathPoint ChangeTarget(PathPoint Target_point)
    {
        return Target_point?.NextPoint;
    }

    public void CheckTarget()
    {
        if(GetDistanceToTarget(_currentTarget.gameObject.transform.position) <= 0.1f)
        {
            PathPoint tmp = _currentTarget.gameObject.GetComponent<PathPoint>();
            if (tmp != null)
                _currentTarget = ChangeTarget(tmp);
            else
                _currentTarget = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet_BH tmp = other.GetComponent<Bullet_BH>();
        tmp?.MakeDamage(this);
    }
}
