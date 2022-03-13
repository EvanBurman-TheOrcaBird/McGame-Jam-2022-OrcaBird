using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Rigidbody2D rbPlayer;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c == rbPlayer.gameObject.GetComponent<PlayerMovement>().footCollider)
        {
            Debug.Log("land"); // This is where sound goes
        }
    }


}
