using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Candle : MonoBehaviour
{
    Rigidbody2D rb;
    public float throwSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnThrow()
    {
        //Vector2 throwDir = OnMove.value;

        rb.velocity = new Vector2(throwSpeed, throwSpeed);
        Debug.Log("throw");
    }

    void Update()
    {
        
    }
    
}
