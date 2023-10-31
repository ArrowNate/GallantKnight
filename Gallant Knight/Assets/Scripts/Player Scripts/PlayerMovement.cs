using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float horizontalMovement;

    private Rigidbody2D pRB;

    private PlayerAnimations playerAnimation;

    private void Awake()
    {
        pRB = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw(TagManager.HORIZONTAL_MOVEMENT_AXIS);

        HandleAnimation();
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
}