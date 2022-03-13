using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float defaultSpeed = 5f;
    public float speed;
    private Vector2 step;
    private Vector2 climb;
    public Transform spawn;

    public bool movingBox;

    public bool canClimb = false;
    public float ladderX;

    public float jumpHeight = 10f;
    public float jumpHeightCandle = 6f;
    public Candle candle;
    private Vector2 jumpSpeed;
    private bool jumping;
    public BoxCollider2D footCollider;
    public CapsuleCollider2D handCollider;
    private float offset;
    private Animator Animator;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();
        rb.transform.localPosition = spawn.position;
        handCollider = GetComponents<CapsuleCollider2D>()[1]; // relies on order in inspector
        speed = defaultSpeed;


    }

    void OnMove(InputValue inputVal)
    {
        step = inputVal.Get<Vector2>();
        climb = new Vector2(0, step.y);
        step = new Vector2(step.x, 0);
    }

    void OnJump()
    {
        if (!footCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !footCollider.IsTouchingLayers(LayerMask.GetMask("Boxes"))){
            return;
        }
        jumping = true;
        movingBox = false;
        speed = defaultSpeed;
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
        if (step.x != 0)
        {
            if (!movingBox) { transform.localScale = new Vector2(Mathf.Sign(step.x), 1f); }
            Animator.SetBool("isRunning", true);
        }
        else
        {
            Animator.SetBool("isRunning", false);
        }
        if (footCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
        }
        // rb.position = new Vector2(ladderX, rb.position.y);
        transform.position = (rb.position + step * speed * Time.fixedDeltaTime);
        if (jumping)
        {
            rb.AddForce(jumpSpeed, ForceMode2D.Impulse);
            jumping = false;
        }
        if (!footCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !footCollider.IsTouchingLayers(LayerMask.GetMask("Boxes"))) { 
            if (rb.velocity.y > 0)
            {
                Animator.SetBool("isRising", true);
                
            } 
            else if (rb.velocity.y < 0)
            {
                Animator.SetBool("isFalling", true);
            }
        }
        else
        {
            Animator.SetBool("isRising", false);
            Animator.SetBool("isFalling", false);
        }
        Die();
        
    }


    void Die()
    {
        if (footCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            rb.transform.localPosition = spawn.position;
            candle.thrown = false;
            Debug.Log("death");
            
        }
    }
}
