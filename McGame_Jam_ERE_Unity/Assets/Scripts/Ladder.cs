using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public Rigidbody2D rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c == rbPlayer.gameObject.GetComponent<PlayerMovement>())
        {
            rbPlayer.GetComponent<PlayerMovement>().canClimb = true;
            rbPlayer.GetComponent<PlayerMovement>().ladderX = transform.position.x;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c == rbPlayer.gameObject.GetComponent<PlayerMovement>())
        {
            rbPlayer.GetComponent<PlayerMovement>().canClimb = false;
        }
    }

}
