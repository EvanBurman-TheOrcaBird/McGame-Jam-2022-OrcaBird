using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player")) {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            UI.getPainting();
        }
    }

}
