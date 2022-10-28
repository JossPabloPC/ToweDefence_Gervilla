using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPooler : Pooler
{
    private static TowerPooler instance;
    public static TowerPooler Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }
    public GameObject SpawnTower(Transform tranform, TowerData data)
    {
        GameObject tmp = pool.Get();
        tmp.GetComponent<Tower_BH>().data = data;
        tmp.GetComponent<Tower_BH>().AssignTowerData();
        tmp.transform.position = transform.position;
        tmp.transform.rotation = transform.rotation;

        return tmp;
    }
    public GameObject SpawnTower(Vector3 position, Quaternion rotation, TowerData data)
    {
        GameObject tmp = pool.Get();
        tmp.GetComponent<Tower_BH>().data = data;
        tmp.GetComponent<Tower_BH>().AssignTowerData();
        tmp.transform.position = position;
        tmp.transform.rotation = rotation;

        return tmp;
    }

    public void ReturnTowerToPool(GameObject tower)
    {
        pool.Release(tower);
    }
}
