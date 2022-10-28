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


    protected virtual void OnEnable()
    {
        _canFire            = true;
        _collider           = gameObject.GetComponent<SphereCollider>();
        _collider.isTrigger = true;
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
            BulletPooler.Instance.SpawnBullet(canonEnd.position, canonEnd.rotation);
            StartCoroutine(StartClockToFire());
        }
    }
    private IEnumerator StartClockToFire()
    {
        _canFire = false;
        yield return new WaitForSeconds(RealRateOfFire);
        _canFire = true;
    }

}
