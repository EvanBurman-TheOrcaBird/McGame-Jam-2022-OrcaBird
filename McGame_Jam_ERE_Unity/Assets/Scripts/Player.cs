using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float throwSpeed = 5f;
    Vector2 playerInput = new Vector2(0f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }

    /*void OnThrow()
    {
        rbCandle.velocity = new Vector2(throwSpeed*playerInput.x, throwSpeed*playerInput.y);
        Debug.Log("throw");
    }*/

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(playerInput.x * 5f, rb.velocity.y);
    }

    
}
