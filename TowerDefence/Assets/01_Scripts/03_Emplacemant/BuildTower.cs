using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildTower : MonoBehaviour
{
    [SerializeField]private GameData    _gameData;

    private bool        _towerUsed;

    private void Start()
    {
        _towerUsed = false;
    }

    public void Build(TowerData data)
    {
        if (!_towerUsed && _gameData._TowerSelected != null)
        {
            _towerUsed  = true;
            TowerPooler.Instance.SpawnTower(transform.position + Vector3.up * 0.66f, Quaternion.identity, data);
        }
    }

}
