using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UI
{
    public static int paintingCount = 0;



    public static void getPainting()
    {
        paintingCount++;
        if (paintingCount == 3)
        {
            GameObject.Find("ClaireText").GetComponent<TextMesh>().text = "You did it!";
            GameObject.Find("ClaireText").GetComponent<Animator>().SetBool("hasText", true);
        }
    }

}
