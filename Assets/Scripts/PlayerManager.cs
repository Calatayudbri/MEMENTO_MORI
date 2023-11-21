using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    // private Animator anim;
    private bool isGrounded;
    private bool canJump = true;

  public Animator anim_;

  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGrounded();

        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);

        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
             Jump();   
        }
        if(canJump)
        {
            anim_.SetBool("isGrounded", true);
        }else{
            anim_.SetBool("isGrounded", false);
        }

        // UpdateAnimation(horizontalInput);
    }

    void Move(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;
        FlipCharacter(horizontalInput);
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
    {
        anim_.SetBool("Running",true);
    }else{
        anim_.SetBool("Running", false);
    }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        canJump = false;

  }

    void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.Raycast(this.transform.position,Vector3.down,0.5f,groundLayer.value);

        if (isGrounded)
        {
            canJump = true;
        }
            
    
    }

    // void UpdateAnimation(float horizontalInput)
    // {
    //     anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
    //     anim.SetBool("IsGrounded", isGrounded);
    // }
}
