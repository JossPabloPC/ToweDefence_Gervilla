using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameManager : MonoBehaviour
{
    public static Scr_GameManager Instance;

    public delegate void Notify();
    public event Notify OnGameOver;

    [SerializeField] private GameData   _gameData;
    [SerializeField] private City       _city;

    private void Awake()
    {
        Instance = this;
    }
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
        OnGameOver.Invoke();
    }
}
