using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 step;

    public bool movingObj;

    public float jumpHeight = 10f;
    public float jumpHeightCandle = 6f;
    public Candle candle;
    private Vector2 jumpSpeed;
    private bool jumping;
    private BoxCollider2D footCollider;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footCollider = GetComponent<BoxCollider2D>();
        

    }

    void OnMove(InputValue inputVal)
    {
        step = inputVal.Get<Vector2>();
        step = new Vector2(step.x, 0);
    }

    void OnJump()
    {
        if (!footCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }
        jumping = true;
        movingObj = false;
    }

    void FixedUpdate()
    {
        if (candle.thrown)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            jumpSpeed = new Vector2(0f, jumpHeight);

        }
        else {
            transform.GetChild(0).gameObject.SetActive(false);
            jumpSpeed = new Vector2(0f, jumpHeightCandle);
        }
        if(step.x != 0) transform.localScale = new Vector2(Mathf.Sign(step.x), 1f);
        transform.position = (rb.position + step * speed * Time.fixedDeltaTime);
        if (jumping)
        {
            rb.AddForce(jumpSpeed, ForceMode2D.Impulse);
            jumping = false;
        }
        Die();
        
    }


    void Die()
    {
        if (footCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            rb.transform.localPosition = new Vector2(0f, 0f);
            Debug.Log("death");
        }
    }
}
