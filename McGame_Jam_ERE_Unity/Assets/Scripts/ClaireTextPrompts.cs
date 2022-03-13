using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaireTextPrompts : MonoBehaviour
{
    public int promptNumber;

    void Start()
    {
        GameObject.Find("ClaireText").GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
        GameObject.Find("ClaireText").GetComponent<MeshRenderer>().sortingOrder = 10;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag("Player")) {
            GameObject.Find("ClaireText").GetComponent<ClaireText>().Prompt(promptNumber);
            GameObject.Find("ClaireText").GetComponent<Animator>().SetBool("hasText", true);
            
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            GameObject.Find("ClaireText").GetComponent<Animator>().SetBool("hasText", false);
        }
    }
}
