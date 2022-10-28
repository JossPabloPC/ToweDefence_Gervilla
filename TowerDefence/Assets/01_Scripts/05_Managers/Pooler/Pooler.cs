using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooler : MonoBehaviour
{
    [SerializeField] protected GameObject _object;
    [SerializeField] protected int _defaultCapacity;
    [SerializeField] protected int _maxCapacity;
    public static ObjectPool<GameObject> pool;
    

    protected virtual void Start()
    {
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(_object);
        }, GameObject =>
        {
            GameObject.gameObject.SetActive(true);
        }, GameObject =>
        {
            GameObject.gameObject.SetActive(false);
        }, GameObject =>
        {
            Destroy(GameObject.gameObject);
        }, false, _defaultCapacity, _maxCapacity);
    }

}
