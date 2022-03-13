using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaireTextPrompts : MonoBehaviour
{
    public int promptNumber;

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag("Player")) {
            GameObject.Find("ClaireText").GetComponent<ClaireText>().Prompt(promptNumber);
            GameObject.Find("ClaireText").GetComponent<Animator>().SetBool("hasText", true);
            Debug.Log(GameObject.Find("ClaireText").GetComponent<Animator>().GetBool("hasText"));
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
