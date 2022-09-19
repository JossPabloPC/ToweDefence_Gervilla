using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{
    [SerializeField]private GameObject _tower;
    
    private bool _towerUsed;

    private void Start()
    {
        _towerUsed = false;
    }

    public void Build()
    {
        if (!_towerUsed)
        {
            _towerUsed = true;
            Instantiate(_tower, transform.position + Vector3.up * 0.66f, Quaternion.identity);
        }
    }
}
