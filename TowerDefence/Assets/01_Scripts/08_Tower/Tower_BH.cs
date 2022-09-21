using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_BH : ObjectWithGun
{
    [SerializeReference] private TowerData data;
    [SerializeReference]private Transform _canonEnd;


    protected override void Start()
    {
        base.Start();
        AssignGunStats();
    }
    protected override void AssignGunStats()
    {
        _rateOfFire         = data.rateOfFire;
        _range              = data.range;
        _projectile         = data.projectile;
        _collider.radius    = _range;
    }

    private void OnDrawGizmosSelected()
    {
        if (data != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(gameObject.transform.position, data.range);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Enemy_BH tmp = other.GetComponent<Enemy_BH>();
        if (tmp != null)
        {
            transform.LookAt(tmp.transform, Vector3.up);
            Fire(_canonEnd);
        }
    }
}
