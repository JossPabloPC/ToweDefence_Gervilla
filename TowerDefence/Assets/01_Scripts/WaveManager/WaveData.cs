using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WaveData", menuName ="ScriptableObjects/Wave data", order = 1)]
[SerializeField]
public class WaveData : ScriptableObject
{
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
        enemiesToSpawn = new List<int>();
        for (int i = 0; i < enemyBudget; i++)
        {
            enemiesToSpawn.Add(Random.Range(0, enemies.Length));
        }
    }
}
