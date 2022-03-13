using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UI
{
    static int paintingCount = 0;



    public static void getPainting()
    {
        paintingCount++;
        Debug.Log(paintingCount);
    }

}
