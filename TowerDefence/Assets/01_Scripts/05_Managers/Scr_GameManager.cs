using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameManager : MonoBehaviour
{
    [SerializeField] private GameData   _gameData;
    [SerializeField] private City       _city;
    void Start()
    {
        _city.OnDeath += CityDamaged;
        Cursor.visible = true;
        setGameData();
    }


    private void setGameData()
    {
        _gameData._credit = 0;
        _gameData._TowerSelected = null;
    }

    private void CityDamaged()
    {
        Debug.Log("City Destroyed!");
    }
}
