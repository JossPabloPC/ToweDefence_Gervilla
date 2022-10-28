using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{

    [SerializeField] private GameData _gameData;

    public void ButtonClicked(TowerData towerData)
    {
        _gameData._TowerSelected = towerData;
    }
}
