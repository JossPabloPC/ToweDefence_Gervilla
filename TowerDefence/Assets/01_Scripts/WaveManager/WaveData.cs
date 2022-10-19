using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WaveData", menuName ="ScriptableObjects/Wave data", order = 1)]
[SerializeField]
public class WaveData : ScriptableObject
{
    private List<int>           _idxOfEnemiesOnBudget;
    private int                 _availableBudget;

    public string               spawnPointsTag;
    public List <PathPoint>     spawnPoints;
    public GameObject[]         enemies;
    public int                  enemyBudget;
    public List <int>           enemiesToSpawn;


    public void spawnEnemy()
    {
        if (spawnPoints != null && spawnPoints.Count > 0)
        {
            PathPoint tmp = spawnPoints[Random.Range(0,spawnPoints.Count)];
            GameObject tmpEnemy = Instantiate(enemies[enemiesToSpawn[0]], tmp.transform.position, Quaternion.identity);
            tmpEnemy.GetComponent<Enemy_BH>().CurrentTarget = tmp;
            enemiesToSpawn.RemoveAt(0);
        }
    }
    public void CalculateEnemiesToSpawn()
    {
        _availableBudget = enemyBudget;
        int randIdx;
        while (_availableBudget > 0) {
            SetEnemiesOnBudget();
            
            if(_idxOfEnemiesOnBudget.Count == 0)
                break;
            
            randIdx = Random.Range(0,_idxOfEnemiesOnBudget.Count);
            enemiesToSpawn.Add(randIdx);
            _availableBudget -= enemies[_idxOfEnemiesOnBudget[randIdx]].GetComponent<Enemy_BH>()._enemyData._budgetCost;
        }
    }

    private void SetEnemiesOnBudget()
    {
        _idxOfEnemiesOnBudget = new List<int>();
        Enemy_Data tmpenemyData;
        for (int i = 0; i < enemies.Length; i++)
        {
            tmpenemyData = enemies[i].GetComponent <Enemy_BH>()._enemyData;
            if (tmpenemyData._budgetCost <= _availableBudget)
            {
                _idxOfEnemiesOnBudget.Add(i);
            }
        }
    }
}
