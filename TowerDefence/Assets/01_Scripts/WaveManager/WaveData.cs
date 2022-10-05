using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WaveData", menuName ="ScriptableObjects/Wave data", order = 1)]
[SerializeField]
public class WaveData : ScriptableObject
{
    public string       spawnPointsTag;
    public Transform[]  spawnPoints;
    public Enemy_Data[] enemies;
    public int enemyBudget;
    [SerializeField] private List<GameObject> enemiesOnScene = new List<GameObject>();
    public List <int> _enemiesToSpawn;

    public void spawnEnemy(GameObject enemy)
    {
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            Transform tmp = spawnPoints[Random.Range(0,spawnPoints.Length)];
            Instantiate(enemy, tmp);
        }
    }

    public void CheckEnemiesStatus()
    {
        for (int i = 0; i < enemiesOnScene.Count; i++)
        {
            if (!enemiesOnScene[i].activeInHierarchy)
                enemiesOnScene.RemoveAt(i);
        }
    }

    public void CalculateEnemiesToSpawn()
    {
        _enemiesToSpawn = new List<int>();
        for (int i = 0; i < enemyBudget; i++)
        {
            _enemiesToSpawn.Add(Random.Range(0, enemies.Length));
        }
    }
}
