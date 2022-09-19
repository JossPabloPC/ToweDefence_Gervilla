using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Scr_ClickObject : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    public void LauchRay()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if(hit.transform != null)
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
