using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppConstants
{
    private static readonly string MENUSCENE     = "Menu"; 
    private static readonly string LEVEL_01      = "Level01";



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
    MENU, LEVEL_01
}
