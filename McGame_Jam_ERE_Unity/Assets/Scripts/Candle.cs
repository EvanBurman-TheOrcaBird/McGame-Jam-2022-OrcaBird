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
    public bool thrown = false;
    private Vector2 playerInput = new Vector2(0f, 0f);
    public Transform holdPoint;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(rbPlayer.gameObject.GetComponent<CapsuleCollider2D>(), box);
        Physics2D.IgnoreCollision(rbPlayer.gameObject.GetComponent<BoxCollider2D>(), box);
        Physics2D.IgnoreCollision(GetComponents<CapsuleCollider2D>()[1], box);
        Physics2D.IgnoreCollision(GetComponents<CapsuleCollider2D>()[1], GetComponent<CapsuleCollider2D>());
    }
    void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
    void OnThrow()
    {
        if (thrown) return;
        thrown = true;
        Vector2 throwVector;
        
        if (playerInput.magnitude > Mathf.Epsilon)
        {
            throwVector = throwSpeed * playerInput;
            Debug.Log(playerInput);
        }
        else{
            throwVector = new Vector2(rbPlayer.transform.localScale.x, 0f);
        }

        rb.velocity = new Vector2(throwVector.x + rbPlayer.velocity.x, throwVector.y);
        
    }

    void Update()
    {
        if (!thrown && !rbPlayer.gameObject.GetComponent<PlayerMovement>().movingBox)
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
        if (collision.isTrigger) return;
        if (collision.CompareTag("Player") && (box.IsTouchingLayers(LayerMask.GetMask("Ground")) || (box.IsTouchingLayers(LayerMask.GetMask("Boxes")))))
        {
            thrown = false;
            Debug.Log("pickup");
        }
    }
}
