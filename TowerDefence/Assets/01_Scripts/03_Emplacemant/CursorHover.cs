using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CursorHover : MonoBehaviour
{
    public UnityEvent _onMouseHover;
    public UnityEvent _onMouseExit;

    [System.Serializable]
    public class PossibleBuild : UnityEvent<Transform> { }
    private void OnMouseEnter()
    {
        _onMouseHover.Invoke();
        Scr_GameManager.Instance.TransportHologram(transform);
    }

    private void OnMouseExit()
    {
        _onMouseExit.Invoke();
    }
}
