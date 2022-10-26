  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int _currentWave = 0;
    public WaveData[] waves;


    public int GetCurrentWave { get { return _currentWave; } }
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

    private void StartNewWave()
    {
        if(_currentWave < waves.Length)
        {
            waves[_currentWave].CalculateEnemiesToSpawn();
            StartCoroutine(TimeNextEnemy(1));
        }
    }

    public void WaitForNewWave()
    {
        StartCoroutine(TimeNextWave(10));
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
        _currentWave++;
    }

    private IEnumerator TimeNextWave(float time)
    {
        float clock = 0;
        while (clock <= time)
        {
            clock += Time.deltaTime;
            Debug.Log(clock);
            yield return new WaitForEndOfFrame();
        }
        StartNewWave();
    }
}
