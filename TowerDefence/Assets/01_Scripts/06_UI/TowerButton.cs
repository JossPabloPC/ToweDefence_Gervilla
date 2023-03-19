using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerButton : MonoBehaviour
{

    [SerializeField] private GameData _gameData;
    [SerializeField] private TMP_Text _towerCostText;
    [SerializeField] private TowerData _towerData;

    private void Start()
    {
        _towerCostText.text = _towerData.cost.ToString();
    }

    public void ButtonClicked()
    {
        _gameData.towerSelected = _towerData;
    }
}
