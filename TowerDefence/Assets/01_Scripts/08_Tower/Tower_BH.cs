using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_BH : ObjectWithGun
{
    [SerializeReference] private TowerData data;
    [SerializeReference] private Transform _canonEnd;

    [SerializeReference] private List<Enemy_BH> _enemiesOnTarget;


    protected override void Start()
    {
        base.Start();
        AssignGunStats();
    }

    protected override void Update()
    {
        base.Update();
        LockOnTarget();
    }
    protected override void AssignGunStats()
    {
        _rateOfFire = data.rateOfFire;
        _range = data.range;
        _projectile = data.projectile;
        _collider.radius = _range;
    }

    private void OnDrawGizmosSelected()
    {
        if (data != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(gameObject.transform.position, data.range);
        }
    }

    private void LockOnTarget()
    {
        if (_enemiesOnTarget.Count > 0)
        {
            transform.LookAt(_enemiesOnTarget[0].transform);
            Fire(_canonEnd);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy_BH tmp = other.GetComponent<Enemy_BH>();
        if (tmp != null)
        {
            _enemiesOnTarget.Add(tmp);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy_BH tmp = other.GetComponent<Enemy_BH>();
        
        if(_enemiesOnTarget.Contains(tmp)) //el target salio del scope
        {
            _enemiesOnTarget.Remove(tmp);
        }
    }

}
