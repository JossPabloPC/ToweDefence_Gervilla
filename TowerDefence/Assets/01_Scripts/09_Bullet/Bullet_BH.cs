using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_BH : MonoBehaviour, I_MakeDamage
{
    [SerializeReference] private Bullet_Data _bullet_Data;

    void Update()
    {
        transform.Translate(gameObject.transform.forward * _bullet_Data.speed * Time.deltaTime, Space.World);
    }

    public void MakeDamage(Damagable_Body damagable_Body)
    {
        damagable_Body.receiveDamage(_bullet_Data.damage);
    }
}
