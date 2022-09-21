using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    [SerializeField]private PathPoint[] _nextPoints;
    public PathPoint NextPoint
    {
        get 
        {
            PathPoint tmp;
            if (_nextPoints != null && _nextPoints.Length > 0)
                tmp = _nextPoints[Random.Range(0, _nextPoints.Length)];
            else tmp = null;
            return tmp;
        }  
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.2f);
        if(_nextPoints != null && _nextPoints.Length > 0)
        {
            for (int i = 0; i < _nextPoints.Length; i++)
            {
                if (_nextPoints[i] != null)
                {
                    Gizmos.DrawLine(transform.position, _nextPoints[i].transform.position);
                }
            }
        }
    }
}
