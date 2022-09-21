using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CursorHover : MonoBehaviour
{
    public UnityEvent _onMouseHover;
    public UnityEvent _onMouseExit;
    private void OnMouseEnter()
    {
        _onMouseHover.Invoke();
    }

    private void OnMouseExit()
    {
        _onMouseExit.Invoke();
    }
}
