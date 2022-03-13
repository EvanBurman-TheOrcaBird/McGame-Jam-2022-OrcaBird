using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Candle"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
