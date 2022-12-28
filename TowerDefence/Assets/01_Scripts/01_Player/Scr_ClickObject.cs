using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Scr_ClickObject : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private GameData _gameData;
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
            if (hit.transform.gameObject != null && _gameData._TowerSelected != null)
            {
                
                BuildTower tmp =  hit.collider.gameObject.GetComponent<BuildTower>();
                if (Scr_GameManager.Instance.credits - _gameData._TowerSelected.cost >= 0)
                {
                    tmp?.Build(_gameData._TowerSelected);
                }
            }
        }
    }
}
