using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WaveData", menuName ="ScriptableObjects/Wave data", order = 1)]
[SerializeField]
public class WaveData : ScriptableObject
{
    private List<int>           _idxOfEnemiesOnBudget;
    private int                 _availableBudget;
    private List<GameObject>    _enemiesSpawned;

    public string               spawnPointsTag;
    public List <PathPoint>     spawnPoints;
    public GameObject[]         enemies;
    public int                  enemyBudget;
    public List <int>           enemiesToSpawn;


    /// <summary>
    /// Selects a random spwan point and spawns an enemy from it.
    /// </summary>
    public void spawnEnemy()
    {
        if (spawnPoints != null && spawnPoints.Count > 0)
        {
            PathPoint tmp = spawnPoints[Random.Range(0,spawnPoints.Count)];
            GameObject tmpEnemy = Instantiate(enemies[enemiesToSpawn[0]], tmp.transform.position, Quaternion.identity);
            AddEnemytoList(true, tmpEnemy);
            tmpEnemy.GetComponent<Enemy_BH>().CurrentTarget = tmp;
            enemiesToSpawn.RemoveAt(0);
        }
    }

    #region waveBudget
    /// <summary>
    /// Calcualtes the enemies that will be spawned in that wave
    /// </summary>
    public void CalculateEnemiesToSpawn()
    {
        _enemiesSpawned     = new List<GameObject>();
        _availableBudget    = enemyBudget;
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

    /// <summary>
    ///Chacks waht enemies are still able to be spawned
    /// </summary>
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
    #endregion

    //PROGRAMAR SABER EL ESTADO DE LOS ENEMIGOS SPAWNEADOS
    public void AddEnemytoList(bool printList, GameObject enemy)
    {
        _enemiesSpawned.Add(enemy);
        if (printList)
            Debug.Log(_enemiesSpawned.Count);
    }

    public void RemoveEnemyFromList(bool printList, GameObject enemy)
    {
        _enemiesSpawned.Remove(enemy);
        if (printList)
            Debug.Log(_enemiesSpawned.Count);
        if(_enemiesSpawned.Count == 0)
        {
            WaveManager.Instance.WaitForNewWave();
        }
    }


}
