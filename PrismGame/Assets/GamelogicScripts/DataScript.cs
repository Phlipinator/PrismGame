using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataScript
{
    private static int timeLeft;
    private static int gamemode;  

    public static int TimeLeft
    {
        get
        {
            return timeLeft;
        }

        set
        {
            timeLeft = value;
        }
    }

    public static int Gamemode
    {
        get
        {
            return gamemode;
        }

        set
        {
            gamemode = value;
        }
    }
}
