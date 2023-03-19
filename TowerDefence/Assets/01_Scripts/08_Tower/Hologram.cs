using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        Scr_GameManager.Instance.OnBaseHover += MouseHover;
    }

    public void MouseHover(Transform transform)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = transform.position;
        gameObject.transform.position += Vector3.up;
        gameObject.transform.rotation = transform.rotation;
    }
}
