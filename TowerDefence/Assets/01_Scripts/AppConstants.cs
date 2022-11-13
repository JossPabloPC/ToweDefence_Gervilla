using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppConstants
{
    public  static readonly string MENUSCENE     = "Menu"; 
    public  static readonly string LEVEL_01      = "Level01";



    public static string GetScene(Scenes scene)
    {
        string res = "";
        switch (scene)
        {
            case Scenes.MENU:
                res = MENUSCENE;
                break;
            case Scenes.LEVEL_01:
                res = LEVEL_01;
                break;
        }
        return res;
    }
}

public enum Scenes
{
    MENU = 0, LEVEL_01 = 1
}
