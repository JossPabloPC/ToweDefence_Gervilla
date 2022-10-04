using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WaveData", menuName ="ScriptableObjects/Wave data", order = 1)]
[SerializeField]
public class WaveData : ScriptableObject
{
    public Transform[] spawnPoints;
    public Enemy_Data[] enemies;
    public int enemyBudget;

    public void spawnEnemy()
    {
        if (spawnPoints != null && spawnPoints.Length > 0)
        {

        }
    }
}
