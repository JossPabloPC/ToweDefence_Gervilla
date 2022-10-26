using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ObjectWithGun : MonoBehaviour
{
    protected   float           _rateOfFire;
    protected   GameObject      _projectile;
    protected   float           _range;
    protected   SphereCollider  _collider; 
    private     bool            _canFire;


    protected float RealRateOfFire
    {
        get { return 1/_rateOfFire; }
    }


    protected virtual void Start()
    {
        _canFire            = true;
        _collider           = gameObject.GetComponent<SphereCollider>();
        _collider.isTrigger = true;
    }

    protected virtual void Update()
    {
        UpdateClockToFire();
    }

    protected virtual void AssignGunStats(){}
    /// <summary>
    /// Instantiates a projectile on the canon end tranform
    /// </summary>
    /// <param name="canonEnd"></param>
    protected void Fire(Transform canonEnd)
    {
        if (_canFire)
        {
            Instantiate(_projectile, canonEnd.position, canonEnd.rotation);
        }
    }
    private IEnumerator UpdateClockToFire()
    {
        _canFire = false;
        yield return new WaitForSeconds(RealRateOfFire);
        _canFire = true;
    }

}
