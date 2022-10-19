using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyData", order = 2)]
public class Enemy_Data : AliveObject
{
    public float _speed;
    public int   _budgetCost;
}
