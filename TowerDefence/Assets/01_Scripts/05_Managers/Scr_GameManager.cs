using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameManager : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    void Start()
    {
        Cursor.visible = true;
        setGameData();
    }


    private void setGameData()
    {
        _gameData._credit = 0;
        _gameData._TowerSelected = null;
    }
}
