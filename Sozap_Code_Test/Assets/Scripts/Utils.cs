using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{
    public static int Vertical, Horizontal, Colums, Rows;
    public static int currentlevel = 0;
    public static Vector3 GridToWorldPosition(int x, int y)
    {
        return new Vector3(x - (Horizontal - 0.5f), y - (Vertical - 0.5f));
    }

    public static int GetTile(int x, int y)
    {
        if (y == Rows - 1 && x == 0)
            return 0;
        else if (y == Rows - 1 && x != 6 && x != 7 && x != Colums - 1)
            return 1;
        else if (y == 8 && x != 6 && x != 7 && x != Colums - 1)
            return 1;

        else if (y == Rows - 1 && x == Colums - 1)
            return 2;
        else if (x == 0 && y != 0 && y != Rows - 1)
            return 3;
        else if (x == Colums - 1 && y != 0 && y != Rows - 1)
            return 5;
        else if (x == 0 && y == 0)
            return 6;
        else if (x != 0 && x != Colums - 1 && y == 0)
            return 7;
        else if (x == Colums - 1 && y == 0)
            return 8;
        else if (x == 0 && y == 0)
            return 9;
        else
            return 4;
    }

    public static bool IsEdgeTile(int x, int y)
    {
        if (y == Rows - 1 && x == 0)
            return true;
        else if (y == Rows - 1 && x != 6 && x != 7 && x != Colums - 1)
            return true;
        else if (y == 8 && x != 3 && x != 7 && x != Colums - 1)
            return true;

        else if (y == Rows - 1 && x == Colums - 1)
            return true;
        else if (x == 0 && y != 0 && y != Rows - 1)
            return true;
        else if (x == Colums - 1 && y != 0 && y != Rows - 1)
            return true;
        else if (x == 0 && y == 0)
            return true;
        else if (x != 0 && x != Colums - 1 && y == 0)
            return true;
        else if (x == Colums - 1 && y == 0)
            return true;
        else if (x == 0 && y == 0)
            return true;
        else
            return false;
    }

}
