using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_BH : ObjectWithGun
{
    public TowerData data;
    [SerializeReference] private Transform _canonEnd;

    [SerializeReference] private List<Enemy_BH> _enemiesOnTarget;


    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected  void Update()
    {
        LockOnTarget();
    }


    private void OnDrawGizmosSelected()
    {
        if (data != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(gameObject.transform.position, data.range);
        }
    }

    #region Attack Enemies
    private void LockOnTarget()
    {
        CheckListStatus();
        if (_enemiesOnTarget.Count > 0)
        {
            transform.LookAt(_enemiesOnTarget[0].transform);
            Fire(_canonEnd);
        }

    }

    private void CheckListStatus()
    {
        for (int i = 0; i < _enemiesOnTarget.Count; i++)
        {
            if (!_enemiesOnTarget[i].gameObject.activeInHierarchy)
            {
                _enemiesOnTarget.RemoveAt(i);
            }
        }
    }
    #endregion

    #region Collisons
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

#endregion

    #region ScriptableObj
    public void AssignTowerData()
    {
        GetComponent<MeshFilter>().mesh = data.mesh;
        GetComponent<MeshRenderer>().material = data.material;

        _rateOfFire = data.rateOfFire;
        _range = data.range;
        _projectile = data.projectile;
        _collider.radius = _range;

        AssignGunStats();
    }

    protected override void AssignGunStats()
    {
        _rateOfFire = data.rateOfFire;
        _range = data.range;
        _projectile = data.projectile;
        _collider.radius = _range;
    }
    #endregion

}
