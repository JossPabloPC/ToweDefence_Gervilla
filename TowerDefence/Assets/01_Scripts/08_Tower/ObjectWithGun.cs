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
            BulletPooler.Instance.SpawnBullet(canonEnd.transform.position, canonEnd.transform.rotation);
            RaycastHit hit;
            Ray ray = new Ray(canonEnd.transform.position, canonEnd.forward);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(canonEnd.transform.position, canonEnd.forward * hit.distance, Color.red, 10);
                Damagable_Body temp = hit.rigidbody.gameObject.GetComponent<Damagable_Body>();
                temp?.receiveDamage(1);
            }
            else
            {
                Debug.DrawRay(canonEnd.transform.position, canonEnd.forward * 1000, Color.white, 0.3f);
                Debug.Log("Did not Hit");
            }
            //BulletPooler.Instance.SpawnBullet(canonEnd.position, canonEnd.rotation);
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
