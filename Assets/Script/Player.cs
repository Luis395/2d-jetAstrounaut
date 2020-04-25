using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rb;
    bool isGrounded;
    bool doubleJump;
    private Animator anim;
    public Ak ak;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * Speed, rb.velocity.y);
        if (movement > 0)
        {
            anim.SetBool("walk", true);
            if (!ak.shooting)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
        if (movement < 0)
        {
            anim.SetBool("walk", true);
            
            if (!ak.shooting)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
           
        }
        if (movement == 0)
        {
            anim.SetBool("walk", false);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0f);
                    rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                    doubleJump = false;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("jump", false);
        if (collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = false;
        }
      
    }
}
