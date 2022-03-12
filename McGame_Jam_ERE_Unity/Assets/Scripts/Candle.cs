using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Candle : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Rigidbody2D rbPlayer;
    BoxCollider2D box;
    public float throwSpeed = 5f;
    // public Vector2 playerInput;
    public bool thrown = false;
    private Vector2 playerInput = new Vector2(0f, 0f);
    private Vector2 lastDir = new Vector2(1f, 0f);
    public Transform holdPoint;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(rbPlayer.gameObject.GetComponent<CapsuleCollider2D>(), box);
    }
    void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
        if (playerInput != new Vector2(0f, 0f))
        {
            lastDir = playerInput;
        }

    }
    void OnThrow()
    {
        if (thrown) return;
        thrown = true;
        Vector2 throwVector;
        if (playerInput != new Vector2(0f, 0f))
        {
            throwVector = throwSpeed * playerInput;
        }
        else
        {
            throwVector = new Vector2(rbPlayer.transform.localScale.x, 0f);
        }

        rb.velocity = new Vector2(throwVector.x + rbPlayer.velocity.x, throwVector.y);
        Debug.Log("throw");
    }

    void Update()
    {
        if (!thrown)
        {
            box.enabled = false;
            rb.transform.localPosition = holdPoint.position;
        }
        else
        {
            box.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && box.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            thrown = false;
            Debug.Log("pickup");
        }
    }
}
