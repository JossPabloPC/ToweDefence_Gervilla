using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameManager : MonoBehaviour
{
    public static Scr_GameManager Instance;

    public delegate void Notify();
    public event Notify OnGameOver;
    public event Notify OnGameWin;

    [SerializeField] private GameData       _gameData;
    [SerializeField] private City           _city;
    [SerializeField] private WaveManager    _waveManager;
    [SerializeField] private Camera         _currentCamera;

    public Camera GetCurrentCamera
    {
        get { return _currentCamera; }
    }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _city.OnDeath += CityDestroyed;
        _waveManager.OnWavesEnded += WavesCleared;
        Cursor.visible = true;
        setGameData();
    }


    private void setGameData()
    {
        _gameData._credit = 0;
        _gameData._TowerSelected = null;
    }

    private void CityDestroyed()
    {
        Debug.Log("City Destroyed!");
        OnGameOver.Invoke();
    }

    private void WavesCleared() {
        Debug.Log("Game winned");
        OnGameWin.Invoke();
    }
}
