using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Scr_GameManager _gameManager;
    private void Start()
    {
        _gameManager = Scr_GameManager.Instance;
    }

    private void Update()
    {
        transform.LookAt(_gameManager.GetCurrentCamera.transform);
    }
}
