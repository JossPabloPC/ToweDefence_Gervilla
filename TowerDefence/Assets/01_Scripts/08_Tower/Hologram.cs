using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        Scr_GameManager.Instance.OnBaseHover        += MouseHover;
        Scr_GameManager.Instance.OnCursorOutOfBase  += MouseOut;
    }

    public void MouseHover(Transform transform)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = transform.position;
        gameObject.transform.position += Vector3.up * .7f;
        gameObject.transform.rotation = transform.rotation;
    }

    public void MouseOut()
    {
        gameObject.SetActive(false);
    }
}
