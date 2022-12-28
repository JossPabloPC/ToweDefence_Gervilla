using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scr_GameManager : MonoBehaviour
{
    public static Scr_GameManager Instance;

    public delegate void Notify();
    public delegate void NotifyInt(int x);
    public event Notify     OnGameOver;
    public event Notify     OnGameWin;
    public event NotifyInt  OnTowerBought;
    public event NotifyInt  OnEnemyKilled;

    public  TMP_Text    creditsText;
    public  int         credits;

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

    public void Towerbought(int cost)
    {
        Instance.credits-= cost;
        OnTowerBought(Instance.credits);
    }

    public void EnemyKilled(int cost)
    {
        Instance.credits += cost;
        OnEnemyKilled(Instance.credits);

    }

    private void setGameData()
    {
        credits                     = _gameData.startingCredits;
        creditsText.text            = credits.ToString();
        _gameData._TowerSelected    = null;
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
