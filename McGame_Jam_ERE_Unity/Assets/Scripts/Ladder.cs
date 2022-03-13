using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public Rigidbody2D rbPlayer;
    
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c == rbPlayer.gameObject.GetComponent<BoxCollider2D>())
        {
            rbPlayer.gravityScale = 0;
            rbPlayer.velocity = new Vector2(0f, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c == rbPlayer.gameObject.GetComponent<BoxCollider2D>())
        {
            rbPlayer.gravityScale = 1;
        }
    }
    
}
