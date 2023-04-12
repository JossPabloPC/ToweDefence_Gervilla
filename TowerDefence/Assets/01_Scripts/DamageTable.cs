using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTable
{
    public static Dictionary<string, float> damageMap = new Dictionary<string, float>();

    public static void CreateDamageMap()
    {
        damageMap.Add("Infantry,Infantry", 1);
        damageMap.Add("Infantry,Tank", 0.2f);
        damageMap.Add("Infantry,Plane", 1);
        damageMap.Add("Infantry,AA", 2);

        damageMap.Add("Tank,Tank", 1);
        damageMap.Add("Tank,Plane", 0.2f);
        damageMap.Add("Tank,AA", 1);
        damageMap.Add("Tank,Infantry", 2);
        
        damageMap.Add("Plane,Plane", 1);
        damageMap.Add("Plane,AA", 0.2f);
        damageMap.Add("Plane,Tank", 2);
        damageMap.Add("Plane,Infantry", 1);
        
        damageMap.Add("AA,AA", 1);
        damageMap.Add("AA,Infantry", 0.2f);
        damageMap.Add("AA,Plane", 2);
        damageMap.Add("AA,Tank", 1);
    }
}

public enum Type
{
    Infantry, Tank, Plane, AA
}
