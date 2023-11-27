using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    // private Animator anim;
    private bool isGrounded;
    private bool canJump = true;
    private float startTime;
  public Animator anim_;

    public bool canMove_left = true;
    public bool canMove_right = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGrounded();
       

        Move();
        

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

        Attack();
        
        // UpdateAnimation(horizontalInput);
    }

  

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
         { this.transform.position += Vector3.right * speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A))
         { this.transform.position += Vector3.left * speed * Time.deltaTime; }
        // Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        // rb.velocity = movement;
        FlipCharacter();
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

    public void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
        anim_.SetBool("attack",true);

        }else{
      anim_.SetBool("attack", false);
    }
    }


    void FlipCharacter()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
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
   
}
