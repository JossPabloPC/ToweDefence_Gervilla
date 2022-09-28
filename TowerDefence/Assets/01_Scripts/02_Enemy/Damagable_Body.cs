using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable_Body : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnReceiveDamage;

    protected   int         _currentHealth;
    public      AliveObject _objectData;
    
    public float CurrentHealthNormalized
    {
        get { return (float)_currentHealth/_objectData._health; }
    }
    public virtual void receiveDamage(int damage)
    {
        _currentHealth -= damage;
        _OnReceiveDamage.Invoke();
        if(_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
