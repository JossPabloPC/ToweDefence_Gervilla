using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : Damagable_Body
{
    public event Notify OnDeath;


    private void OnEnable()
    {
        _currentHealth = _objectData._health;
    }
    protected override void killObject()
    {
        OnDeath.Invoke();
        base.killObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy_BH tmp = other.GetComponent<Enemy_BH>();
        tmp?.AssualtCity(this);
    }
}
