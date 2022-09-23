using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable_Body : MonoBehaviour
{
    protected int _currentHealth;
    public virtual void receiveDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
