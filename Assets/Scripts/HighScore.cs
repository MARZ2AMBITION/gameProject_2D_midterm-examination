using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScore
{
    private const string kEY = "HighScore";

    public static int Load(int stage)
    {
        return PlayerPrefs.GetInt(kEY + "_" + stage, 0);
    }


    public static void Tryset(int stage, int newScore)
    {
        if(newScore <= Load(stage))
        {
            return;

            PlayerPrefs.SetInt(kEY + "_" + stage, newScore);
            PlayerPrefs.Save();
        }
    }
}
