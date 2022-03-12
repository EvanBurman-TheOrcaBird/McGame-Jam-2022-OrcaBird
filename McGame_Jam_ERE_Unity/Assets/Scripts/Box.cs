using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Box : MonoBehaviour

{

    private Rigidbody2D rb;
    public Rigidbody2D rbPlayer;

    private float boxWidth = 1f; // To be set depending on box size
    private float boxHeight = 1f;
    private float heightThreshold = 0.2f;
    public Candle candle;
    bool moveable;
    bool beingMoved;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        beingMoved = false;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.gameObject.name == "Player")
        {
            moveable = true;
            Debug.Log(moveable);
        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.collider.gameObject.name == "Player")
        {
            moveable = false;
            rb.isKinematic = true; // In case
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
            rb.isKinematic = true;
            beingMoved = false;
            rbPlayer.gameObject.GetComponent<PlayerMovement>().movingObj = false;
        }

        else if (moveable && !rbPlayer.gameObject.GetComponent<PlayerMovement>().movingObj && (rbPlayer.transform.localPosition.y < rb.transform.localPosition.y + heightThreshold))
        {
            beingMoved = true;
            rb.isKinematic = false;
            rb.WakeUp();
            rbPlayer.gameObject.GetComponent<PlayerMovement>().movingObj = true;

        }
    }


    void FixedUpdate()
    {
        if (beingMoved)
        {   
            if (rb.transform.localPosition.x > rbPlayer.transform.localPosition.x) 
            {
                rb.transform.localPosition = new Vector2(rbPlayer.transform.localPosition.x + (0.5f + (boxWidth / 2)), rb.transform.localPosition.y);
            } else
            {
                rb.transform.localPosition = new Vector2(rbPlayer.transform.localPosition.x - (0.5f + (boxWidth / 2)), rb.transform.localPosition.y);
            }
        }
    }
}
