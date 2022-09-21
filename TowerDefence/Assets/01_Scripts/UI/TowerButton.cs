using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{

    [SerializeField] private GameData _gameData;

    public void ButtonClicked(GameObject tower)
    {
        _gameData._TowerSelected = tower;
    }
}
