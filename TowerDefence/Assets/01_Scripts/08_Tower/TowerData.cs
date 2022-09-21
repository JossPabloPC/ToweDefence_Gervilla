using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/Tower Data", order = 3)]
public class TowerData : ScriptableObject
{
    public float        rateOfFire;
    public GameObject   projectile;
    public float        range;
}
