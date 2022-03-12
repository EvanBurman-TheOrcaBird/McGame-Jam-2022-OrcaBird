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
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(rbPlayer.gameObject.GetComponent<CapsuleCollider2D>(), box);
    }
    void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
    void OnThrow()
    {
        if (thrown) return;
        //Vector2 throwDir = OnMove.value;
        thrown = true;
        Vector2 throwVector;
        if (playerInput != new Vector2(0f, 0f))
        {
            throwVector = throwSpeed * playerInput;
        }
        else
        {
            throwVector = new Vector2(1f, 0f) * throwSpeed;
        }

        rb.velocity = new Vector2(throwVector.x + rbPlayer.velocity.x, throwVector.y);
        Debug.Log("throw");
    }

    void Update()
    {
        if (!thrown)
        {
            box.enabled = false;
            rb.transform.localPosition = new Vector2(rbPlayer.transform.localPosition.x + 0.5f, rbPlayer.transform.localPosition.y);
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
