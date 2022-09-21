using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scr_InputManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onLeftMouseClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onLeftMouseClick.Invoke();
        }
    }

}
