using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float normalJumpForce = 5f, doubleJumpForce = 5f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D pRB;

    private PlayerAnimations playerAnimation;

    private float jumpForce = 5f;
    private bool canDoubleJump;
    private bool jumped;

    private RaycastHit2D groundCast;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        pRB = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimations>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        canDoubleJump = true;
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw(TagManager.HORIZONTAL_MOVEMENT_AXIS);

        HandleAnimation();
        HandleJumping();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (horizontalMovement > 0)
        {
            pRB.velocity = new Vector2(moveSpeed, pRB.velocity.y);
        }
        else if (horizontalMovement < 0)
        {
            pRB.velocity = new Vector2(-moveSpeed, pRB.velocity.y);
        }
        else
        {
            pRB.velocity = new Vector2(0f, pRB.velocity.y);
        }
    }

    void HandleAnimation()
    {
        if (pRB.velocity.y == 0f)
            playerAnimation.PlayRun(Mathf.Abs((int)pRB.velocity.x));

        playerAnimation.ChangeFacingDirection((int)pRB.velocity.x);
    }

    void HandleJumping()
    {
        IsGrounded();

        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            if (IsGrounded())
            {
                jumpForce = normalJumpForce;
                Jump();
            }
            else
            {

            }
        }
    }

    bool IsGrounded()
    {
        groundCast = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + 0.015f, groundMask);

        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + 0.015f), Color.red);

        return groundCast.collider != null;
    }

    void Jump()
    {
        pRB.velocity = Vector2.up * jumpForce;
    }
}