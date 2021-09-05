using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoftwareSystem 
{
    public static string state = "alpha";
    public static string developingState;

   public static void updateState()
    {
        state = "betha";
    }

    public static void setDevelopingState(string s)
    {
        developingState = s;
    }
    public static void delivers()
    {
        developingState ="delivered";
    }
}
