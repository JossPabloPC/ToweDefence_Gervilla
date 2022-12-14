  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public delegate void Notify();
    public event Notify OnWavesEnded;

    private int _currentWave = 0;
    private float _clock;
    public WaveData[] waves;


    public int CurrentWave
    {
        get { return _currentWave; }
        set
        { 
            _currentWave = value;
            if (_currentWave == waves.Length)
                OnWavesEnded.Invoke();
        }
    }
    public float GetTimeForNextWave { get { return _clock; } }

    public static WaveManager Instance;

    private void Awake()
    {
        Instance = this;

        //Initialize sapwn points
        for(int i = 0; i < waves.Length; i++)
        {
            waves[i].spawnPoints = new List<PathPoint>();
        }
    }
    private void Start()
    {
        StartNewWave();
    }

    /// <summary>
    /// Starts Spawing enemies from the next wave
    /// </summary>
    private void StartNewWave()
    {
        if(_currentWave < waves.Length)
        {
            waves[_currentWave].CalculateEnemiesToSpawn();
            StartCoroutine(TimeNextEnemy(1));
        }
    }

    /// <summary>
    /// Starts the counter for a new Wave
    /// </summary>
    public void WaitForNewWave()
    {
        StartCoroutine(TimeNextWave(3));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator TimeNextEnemy(float time) {
        while (waves[_currentWave].enemiesToSpawn.Count > 0) { 
            float _currTime = 0;
            while (_currTime <= time)
            {
                _currTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            waves[_currentWave].spawnEnemy();
        }
    }

    private IEnumerator TimeNextWave(float time)
    {
        _clock = 0;
        while (_clock <= time)
        {
            _clock += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartNewWave();
    }
}
