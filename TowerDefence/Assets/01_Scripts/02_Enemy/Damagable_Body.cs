using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable_Body : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnReceiveDamage;

    protected   float       _currentHealth;
    public      AliveObject _objectData;


    public float CurrentHealthNormalized
    {
        get { return (float)_currentHealth/_objectData._health; }
    }
    public virtual void receiveDamage(int damage)
    {
        StartCoroutine(reduceHealth(damage));
        if(_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator reduceHealth(int damage)
    {
        float objetivo = _currentHealth - damage;
        do
        {
            _currentHealth -= 0.01f;
            _OnReceiveDamage.Invoke();
            yield return new WaitForEndOfFrame();
        } while (_currentHealth >= objetivo);
    }
}
