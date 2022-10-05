using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveData[] waves;
    private int _currentWave = 0;

    private void Start()
    {
        
    }

    IEnumerator TimeNextEnemy(float time) {
        yield return new WaitForSeconds(time);

    }
}
