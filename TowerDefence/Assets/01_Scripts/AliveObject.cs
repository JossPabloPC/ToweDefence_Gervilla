using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AliveObject", menuName = "ScriptableObjects/Alive Object", order = 1)]
public class AliveObject : ScriptableObject
{
    public int _health;
}
