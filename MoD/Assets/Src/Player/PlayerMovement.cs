using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    public float runSpeed = 3f;
    public float jumpForce = 3f;

    private bool isGrounded = true;
    private bool crouch = false;
    private bool isRight = false;
    private float jumpTime = 2;
    public List<Collider2D> c;
    public float ts;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Time.timeScale = ts;
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        float horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //rb.velocity = new Vector2(horizontalMove, rb.velocity.y);


        animator.SetBool("run", horizontalMove != 0 && isGrounded);

        animator.SetBool("jump", !isGrounded);

        if (horizontalMove < 0)
        {
            isRight = true;
        }
        else if (horizontalMove > 0)
        {
            isRight = false;
        }
        
        spriteRenderer.flipX = isRight;
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint cp = collision.GetContact(0);

        Debug.Log(cp.normal);
    }

}
