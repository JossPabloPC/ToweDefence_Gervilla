using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/Tower Data", order = 3)]
[SerializeField]
public class TowerData : ScriptableObject
{
    public int          cost;
    public float        rateOfFire;
    public GameObject   projectile;
    public float        range;
    public Mesh         mesh;
    public Material     material;
    public Type         anti;
}


