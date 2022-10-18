using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int _currentWave = 0;
    public WaveData[] waves;
    public static List<GameObject> enemiesOnScene = new List<GameObject>();
    
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
        waves[_currentWave].CalculateEnemiesToSpawn();
        StartCoroutine(TimeNextEnemy(1));
    }

    public void CheckEnemiesStatus()
    {
        for (int i = 0; i < enemiesOnScene.Count; i++)
        {
            if (!enemiesOnScene[i].activeInHierarchy)
                enemiesOnScene.RemoveAt(i);
        }
    }
    


    IEnumerator TimeNextEnemy(float time) {
        while (true) { 
            float _currTime = 0;
            while (_currTime <= time)
            {
                _currTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("Spawn enemy");
            waves[_currentWave].spawnEnemy();
        }
    }
}
