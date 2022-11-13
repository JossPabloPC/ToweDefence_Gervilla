using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_BH : MonoBehaviour, I_MakeDamage
{
    [SerializeReference] private Bullet_Data     _bullet_Data;
    [SerializeReference] private TrailRenderer   _trail;
    private void OnEnable()
    {
        _trail.emitting = true;
        StartCoroutine(lifeTime());
    }
    void Update()
    {
        transform.Translate(gameObject.transform.forward * _bullet_Data.speed * Time.deltaTime, Space.World);
    }

    public void MakeDamage(Damagable_Body damagable_Body)
    {
        damagable_Body.receiveDamage(_bullet_Data.damage);
        BulletPooler.Instance.ReturnBulletToPool(this.gameObject);
    }

    private void OnDisable()
    {
        _trail.emitting = false;
        StopAllCoroutines();
    }

    IEnumerator lifeTime()
    {
        float clock = 0;
        while (clock <= _bullet_Data.lifeTime)
        {
            clock += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        BulletPooler.Instance.ReturnBulletToPool(this.gameObject);
    }
}
