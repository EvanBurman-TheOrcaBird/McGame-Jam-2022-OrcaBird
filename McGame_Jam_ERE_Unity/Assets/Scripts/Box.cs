using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Box : MonoBehaviour

{

    private Rigidbody2D rb;
    public Rigidbody2D rbPlayer;

    private float boxWidth;
    private float boxHeight;
    public Candle candle;
    public bool moveable;
    bool beingMoved;
    private BoxCollider2D top;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        beingMoved = false;
        rb.isKinematic = false;
        top = GetComponents<BoxCollider2D>()[1]; // Depends on order in inspector
        Physics2D.IgnoreCollision(rbPlayer.gameObject.GetComponent<BoxCollider2D>(), top);
        BoxCollider2D col = GetComponents<BoxCollider2D>()[0];
        if (transform.rotation.z == 0)
        {
            boxWidth = GetComponents<BoxCollider2D>()[0].size.x;
            boxHeight = GetComponents<BoxCollider2D>()[0].size.y;
        }
        else // For rotated sprite objects
        {
            boxWidth = GetComponents<BoxCollider2D>()[0].size.y;
            boxHeight = GetComponents<BoxCollider2D>()[0].size.x;
        }
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c == rbPlayer.gameObject.GetComponent<PlayerMovement>().handCollider && candle.thrown)
        {
            moveable = true;
            Debug.Log(moveable);
        }
        if (c == rbPlayer.gameObject.GetComponent<PlayerMovement>().footCollider)
        {
            Debug.Log("foot"); // This is where sound goes
            rb.isKinematic = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c == rbPlayer.gameObject.GetComponent<PlayerMovement>().handCollider)
        {
            moveable = false;
            beingMoved = false;
            rbPlayer.gameObject.GetComponent<PlayerMovement>().movingBox = false;
            rbPlayer.gameObject.GetComponent<PlayerMovement>().speed = rbPlayer.gameObject.GetComponent<PlayerMovement>().defaultSpeed;
        }
        if(c == rbPlayer.gameObject.GetComponent<PlayerMovement>().footCollider)
        {
            rb.isKinematic = false;
        }
    }

    void OnThrow()
    {
        if (!candle.thrown)
        {
            return;
        }
        if (beingMoved)
        {
            beingMoved = false;
            rbPlayer.gameObject.GetComponent<PlayerMovement>().movingBox = false;
            rbPlayer.gameObject.GetComponent<PlayerMovement>().speed = rbPlayer.gameObject.GetComponent<PlayerMovement>().defaultSpeed;
        }

        else if (moveable && !rbPlayer.gameObject.GetComponent<PlayerMovement>().movingBox && !top.IsTouchingLayers(LayerMask.GetMask("Boxes")))
        {
            beingMoved = true;
            rbPlayer.gameObject.GetComponent<PlayerMovement>().movingBox = true;
            rbPlayer.gameObject.GetComponent<PlayerMovement>().speed = 1;

        }
    }


    void FixedUpdate()
    {
        if (beingMoved && rbPlayer.gameObject.GetComponent<PlayerMovement>().movingBox)
        {   
            if (rb.transform.localPosition.x > rbPlayer.transform.localPosition.x) 
            {
                rb.transform.localPosition = new Vector2(rbPlayer.transform.localPosition.x + (0.55f + (boxWidth / 2)), rb.transform.localPosition.y);
            } else
            {
                rb.transform.localPosition = new Vector2(rbPlayer.transform.localPosition.x - (0.55f + (boxWidth / 2)), rb.transform.localPosition.y);
            }
        } 
        else
        {
            beingMoved = false;
        }
    }
}
