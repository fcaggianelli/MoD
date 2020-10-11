using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private Vector2 move;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        move = Vector2.zero;
        move.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y *= 0.5f;
            }
        }

        if (move.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (move.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetBool("grounded", grounded);
        animator.SetBool("run", Mathf.Abs(velocity.x) > .1f && grounded);

        targetVelocity = move * maxSpeed;
    }
}
