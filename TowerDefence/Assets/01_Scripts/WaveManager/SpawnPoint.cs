using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathPoint))]
[SerializeField]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private string _spawnTag;

    private void Start()
    {
        for(int i = 0; i < WaveManager.Instance.waves.Length; i++)
        {
            if(string.Compare(_spawnTag, WaveManager.Instance.waves[i].spawnPointsTag) == 0)
            {
                if (WaveManager.Instance.waves[i].spawnPoints == null)
                    WaveManager.Instance.waves[i].spawnPoints = new List<PathPoint>();
                WaveManager.Instance.waves[i].spawnPoints.Add((PathPoint)GetComponent<PathPoint>());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
}
