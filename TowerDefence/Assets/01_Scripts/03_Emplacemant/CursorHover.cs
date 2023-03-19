using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CursorHover : MonoBehaviour
{
    public UnityEvent _onMouseHover;
    public UnityEvent _onMouseExit;

    private BuildTower _buildTower;

    private void Start()
    {
        _buildTower= GetComponent<BuildTower>();
    }

    [System.Serializable]
    public class PossibleBuild : UnityEvent<Transform> { }
    private void OnMouseEnter()
    {
        _onMouseHover.Invoke();
        if(!_buildTower.TowerUsed && Scr_GameManager.Instance.gameData.towerSelected != null)
            Scr_GameManager.Instance.TransportHologram(transform);
    }

    private void OnMouseExit()
    {
        _onMouseExit.Invoke();
        Scr_GameManager.Instance.DeactivateHologram();
    }
}
