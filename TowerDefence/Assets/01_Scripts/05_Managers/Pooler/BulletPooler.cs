using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : Pooler
{
    private static BulletPooler instance;
    public static BulletPooler Instance {get { return instance; }}

    private void Awake()
    {
        instance = this;
    }
    public GameObject SpawnBullet(Transform tranform)
    {
        GameObject tmp = pool.Get();
        tmp.transform.position = transform.position;
        tmp.transform.rotation = transform.rotation;

        return tmp;
    }
    public GameObject SpawnBullet(Vector3 position, Quaternion rotation)
    {
        GameObject tmp = pool.Get();
        tmp.transform.position = position;
        tmp.transform.rotation = rotation;

        //Emit trail
        Bullet_BH bulletBh = tmp.GetComponent<Bullet_BH>();
        bulletBh.trail.time = 0.3f;

        return tmp;
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        Bullet_BH bulletBh = bullet.GetComponent<Bullet_BH>();
        bulletBh.trail.time = 0;
        pool.Release(bullet);
    }
}
