using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildTower : MonoBehaviour
{
    [SerializeField]private GameData    _gameData;

    private GameObject  _tower;
    private bool        _towerUsed;

    private void Start()
    {
        _towerUsed = false;
    }

    public void Build()
    {
        if (!_towerUsed && _gameData._TowerSelected != null)
        {
            _towerUsed  = true;
            _tower      = _gameData._TowerSelected;
            Instantiate(_tower, transform.position + Vector3.up * 0.66f, Quaternion.identity);
        }
    }

}
