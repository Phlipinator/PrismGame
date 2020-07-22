using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataScript
{
    private static int timeLeft;

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
}
