using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable_Body : MonoBehaviour
{
    public delegate void Notify();
    public event Notify OnReceiveDmg;


    protected   float       _currentHealth;
    public      AliveObject _objectData;


    public float CurrentHealthNormalized
    {
        get { return (float)_currentHealth/_objectData._health; }
    }
    public virtual void receiveDamage(int damage)
    {
        MusicManager.Instance.PlaySound("Hurt");
        StartCoroutine(reduceHealth(damage));
    }

    IEnumerator reduceHealth(int damage)
    {
        float objetivo = _currentHealth - damage;
        do
        {
            _currentHealth -= 0.1f;
            OnReceiveDmg.Invoke();
            if (_currentHealth <= 0)
            {
                killObject();
            }
            yield return new WaitForFixedUpdate();
        } while (_currentHealth >= objetivo);

    }

    protected virtual void killObject()
    {
        gameObject.SetActive(false);
    }
}
