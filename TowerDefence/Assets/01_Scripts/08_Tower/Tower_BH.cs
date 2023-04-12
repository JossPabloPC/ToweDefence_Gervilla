using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_BH : ObjectWithGun
{
    public TowerData data;
    [SerializeReference] private Transform _canonEnd;

    [SerializeReference] private List<Enemy_BH> _enemiesOnTarget;

    private Vector3 _targetDirection;    
    private float   _angle;


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
            _targetDirection = _enemiesOnTarget[0].transform.position - transform.position;
            _angle = Vector3.Angle(_targetDirection, transform.forward);
            int sign = Vector3.Cross(transform.forward, _targetDirection).y < 0 ? -1 : 1;
            if (_angle > 5)
            {
                transform.Rotate(0, 10 * sign * Time.deltaTime * data.rotationSpeed, 0);
            }
            if(_angle < 20)
            {
                Fire(_canonEnd, data.gunType);
            }
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
